using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerOfficeStudentResultSystem.Models
{
	public class Student
	{
		[Key]
		public int ID { get; set; }

		[Column(TypeName = "nvarchar(250)")]
		[Required]
		[DisplayName("Subject Name")]
		public string SubjectName { get; set; }

		[Column(TypeName = "nvarchar(250)")]
		[Required]
		[DisplayName("Result Year")]
		public string Year { get; set; }

		[Column(TypeName = "nvarchar(250)")]
		[Required]
		[DisplayName("Program Name")]
		public string Program { get; set; }

		//[Column(TypeName = "nvarchar(250)")]
		//[Required]
		[DisplayName("File Location")]
		public string ExcelPath { get; set; }
	}
}
