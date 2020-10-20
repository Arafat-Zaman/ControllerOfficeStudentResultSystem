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
				//new Student(){ID = 1, SubjectName = "Software_Engineering", Year = "2020", Program = "BSc"}
				

			};
		}

		public Student Add(Student student)
		{
			student.ID = _studentList.Max(e=>e.ID) + 1;
			_studentList.Add(student);
			return student;
		}

		public Student Delete(int ID)
		{
			Student student = _studentList.FirstOrDefault(e => e.ID == ID);
			if(student!=null)
			{
				_studentList.Remove(student);
			}
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

		public Student Update(Student studentChanges)
		{
			Student student = _studentList.FirstOrDefault(e => e.ID == studentChanges.ID);
			if (student != null)
			{
				student.SubjectName = studentChanges.SubjectName;
				student.Year = studentChanges.Year;
				student.Program = studentChanges.Program;
				
			}
			return student;
		}
	}
}
