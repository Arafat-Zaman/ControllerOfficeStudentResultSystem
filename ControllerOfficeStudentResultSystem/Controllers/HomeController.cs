﻿using ControllerOfficeStudentResultSystem.Models;
using ControllerOfficeStudentResultSystem.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerOfficeStudentResultSystem.Controllers
{

	public class HomeController : Controller
	{
		private readonly IStudentRepository _studentRepository;
		private readonly IHostingEnvironment hostingEnvironment;

		public HomeController(IStudentRepository studentRepository,
							IHostingEnvironment	hostingEnvironment)
		{
			_studentRepository = studentRepository;
			this.hostingEnvironment = hostingEnvironment;
		}

		public IActionResult IndexPage()
		{
			return View();
		}

		public ViewResult Index(string searchBy, string search)
		{		

			var model = _studentRepository.GetAllStudents();
			return View(model);
		}
		
		public ViewResult Details(int? ID)
		{
			HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
			{
				Student = _studentRepository.GetStudent(ID??1),
				PageTitle = "Student Details"
			};
			
			return View(homeDetailsViewModel);
		}
		[HttpGet]
		public ViewResult Create()
		{
			
			return View();
		}
		[HttpGet]
		public ViewResult Edit(int ID)
		{
			Student student = _studentRepository.GetStudent(ID);
			StudentEditViewModel studentEditViewModel = new StudentEditViewModel()
			{
				ID = student.ID,
				SubjectName = student.SubjectName,
				Year = student.Year,
				Program = student.Program,
				ExistingExcelPath = student.ExcelPath

			};
			return View(studentEditViewModel);
		}
		[HttpPost]
		public IActionResult Edit(StudentEditViewModel model)
		{
			if (ModelState.IsValid)
			{
				Student student = _studentRepository.GetStudent(model.ID);
				student.SubjectName = model.SubjectName;
				student.Year = model.Year;
				student.Program = model.Program;
				
				if(model.ExcelFile != null)
				{
					if(model.ExistingExcelPath != null)
					{
						string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingExcelPath);
						System.IO.File.Delete(filePath);
					}
					student.ExcelPath = ProcessUploadFile(model);
				}
				_studentRepository.Update(student);
				return RedirectToAction("index");
			}
			return View();
		}

		private string ProcessUploadFile(StudentCreateViewModel model)
		{
			string uniqueFileName = null;
			if (model.ExcelFile != null)
			{
				string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
				uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ExcelFile.FileName;
				string filePath = Path.Combine(uploadFolder, uniqueFileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					model.ExcelFile.CopyTo(fileStream);
				}
			}

			return uniqueFileName;
		}

		[HttpPost]
		public IActionResult Create(StudentCreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				string uniqueFileName = ProcessUploadFile(model);


				Student newStudent = new Student
				{
					SubjectName = model.SubjectName,
					Year = model.Year,
					Program = model.Program,
					ExcelPath = uniqueFileName

				};

				_studentRepository.Add(newStudent);
				return RedirectToAction("details", new { id = newStudent.ID });
			}
			return View();
		}

		public async Task<IActionResult> Download(string filename)
		{
			if (filename == null)
				return Content("filename not present");

			var path = Path.Combine(
						   Directory.GetCurrentDirectory(),
						   "wwwroot/images", filename);

			var memory = new MemoryStream();
			using (var stream = new FileStream(path, FileMode.Open))
			{
				await stream.CopyToAsync(memory);
			}
			memory.Position = 0;

			return File(memory, GetContentType(path), Path.GetFileName(path));

			//return File(memory, GetContentType(path), Path.GetFileName(path).Split('_').Last());

		}

		private string GetContentType(string path)
		{
			var types = GetMimeTypes();
			var ext = Path.GetExtension(path).ToLowerInvariant();
			return types[ext];
		}

		private Dictionary<string, string> GetMimeTypes()
		{
			return new Dictionary<string, string>
			{
				{".txt", "text/plain"},
				{".pdf", "application/pdf"},
				{".doc", "application/vnd.ms-word"},
				{".docx", "application/vnd.ms-word"},
				{".xls", "application/vnd.ms-excel"},
				{".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
				{".png", "image/png"},
				{".jpg", "image/jpeg"},
				{".jpeg", "image/jpeg"},
				{".gif", "image/gif"},
				{".csv", "text/csv"}
			};
		}


	}
}
