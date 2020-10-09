using ControllerOfficeStudentResultSystem.Models;
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

		public ViewResult Index()
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
		[HttpPost]
		public IActionResult Create(StudentCreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				string uniqueFileName = null;
				if(model.ExcelFile != null)
				{
					string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
					uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ExcelFile.FileName;
					string filePath = Path.Combine(uploadFolder, uniqueFileName);
					model.ExcelFile.CopyTo(new FileStream(filePath, FileMode.Create));
				}


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
	}
}
