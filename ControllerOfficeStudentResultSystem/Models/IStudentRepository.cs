using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerOfficeStudentResultSystem.Models
{
	public interface IStudentRepository
	{
		Student GetStudent(int ID);
		IEnumerable<Student> GetAllStudents();
		Student Add(Student student);
		Student Update(Student studentChanges);
		Student Delete(int ID);
	}
}
