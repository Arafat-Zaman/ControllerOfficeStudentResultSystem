using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerOfficeStudentResultSystem.Models
{
	public static class ModelBuilderExtensions
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().HasData(
				new Student
				{
					ID = 1,
					SubjectName = "Software_Engineering",
					Year = "2020",
					Program = "BSc"

				}
				);
		}
	}
}
