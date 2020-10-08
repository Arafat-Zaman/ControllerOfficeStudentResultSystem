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
				new Student(){ID = 1, SubjectName = "SE", Year = "2015", Program = "BSSE", Location = "Selected"},
				new Student(){ID = 2, SubjectName = "SE2", Year = "2015", Program = "BSSE", Location = "Selected"},
				new Student(){ID = 3, SubjectName = "SE3", Year = "2015", Program = "BSSE", Location = "Selected"}

			};
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
