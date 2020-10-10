using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerOfficeStudentResultSystem.ViewModels
{
	public class StudentEditViewModel : StudentCreateViewModel
	{
		public int ID { get; set; }
		public string ExistingExcelPath { get; set; }
	}
}
