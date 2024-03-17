using System;
using System.Collections.Generic;
using System.Text;
using StudentManagement.DAL;
using System.Configuration;

namespace StudentManagement.BLL
{
    public class StudentService
    {
        private StudentRepository _studentRepository = new StudentRepository();

        public void AddStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }
    }
}
