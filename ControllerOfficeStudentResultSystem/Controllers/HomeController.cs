using ControllerOfficeStudentResultSystem.Models;
using ControllerOfficeStudentResultSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerOfficeStudentResultSystem.Controllers
{

	public class HomeController : Controller
	{
		private readonly IStudentRepository _studentRepository;

		public HomeController(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
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
		public RedirectToActionResult Create(Student student)
		{
			Student newStudent=	_studentRepository.Add(student);
			return RedirectToAction("details",new { id = newStudent.ID});
		}
	}
}
