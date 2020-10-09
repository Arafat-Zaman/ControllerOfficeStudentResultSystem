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
					SubjectName = SubjectNamesListEnum.Physics,
					Year = YearListEnum._2020,
					Program = ProgramListEnum.BSc

				},
				new Student
				{
					ID = 2,
					SubjectName = SubjectNamesListEnum.Botany,
					Year = YearListEnum._2020,
					Program = ProgramListEnum.BSc
				}
				);
		}
	}
}
