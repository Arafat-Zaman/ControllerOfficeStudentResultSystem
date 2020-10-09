using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerOfficeStudentResultSystem.Models
{
	public class MockStundentRepository : IStudentRepository
	{
		private List<Student> _studentList;

		public MockStundentRepository()
		{
			_studentList = new List<Student>()
			{
				new Student(){ID = 1, SubjectName = SubjectNamesListEnum.Software_Engineering, Year = YearListEnum._2020, Program = ProgramListEnum.BBA, Location = "Selected"},
				new Student(){ID = 2, SubjectName = SubjectNamesListEnum.Genetics_Engineerg, Year = YearListEnum._2021, Program = ProgramListEnum.BSc, Location = "Selected"},
				new Student(){ID = 3, SubjectName = SubjectNamesListEnum.Physics, Year = YearListEnum._2022, Program = ProgramListEnum.MBA, Location = "Selected"}

			};
		}

		public Student Add(Student student)
		{
			student.ID = _studentList.Max(e=>e.ID) + 1;
			_studentList.Add(student);
			return student;
		}

		public IEnumerable<Student> GetAllStudents()
		{

			return _studentList;
			//throw new NotImplementedException();
		}

		public Student GetStudent(int ID)
		{
			return _studentList.FirstOrDefault(e=>e.ID==ID);		}
		}
}
