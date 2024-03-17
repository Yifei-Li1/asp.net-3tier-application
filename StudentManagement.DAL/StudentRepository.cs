using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web;
using System.Configuration;

namespace StudentManagement.DAL
{
    public class StudentRepository
    {
       
        private string connectionString = ConfigurationManager.ConnectionStrings["SchoolDBContext"].ConnectionString;
        public void AddStudent(Student student)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("INSERT INTO student (FirstName, LastName) VALUES (@FirstName, @LastName)", connection);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (var connection = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("SELECT * FROM student", connection);
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            StudentID = int.Parse(reader["StudentID"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString()
                        });
                    }
                }
            }

            return students;
        }
    }
}
