using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myClassLibrary
{
    public class Group : ISearchable
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; }
        public string Speciality { get; set; }
        public int Course { get; set; }
        public string StudCurator { get; set; }

        public List<Student> SearchStudents(string keyword)
        {
            keyword = keyword.ToLowerInvariant();

            return Students.Where(s =>
                s.Name.ToLower().Contains(keyword) ||
                s.Surname.ToLower().Contains(keyword)
            ).ToList();

        }

        public Student AddStudent(string name, string surname, string lastname, int age, string phoneNumber,
                          Dormitory dormNumber, int? dormRoomNumber, string studentCardNum)
        {
            
            if (Students.Any(s => s.StudentCardNum == studentCardNum))
            {
                throw new InvalidOperationException("Студент з таким номером білета вже існує.");
            }
            var student = new Student(name, surname, lastname, age, phoneNumber, dormNumber, dormRoomNumber, studentCardNum);
            Students.Add(student);
            return student;
        }

        public Group(string name, string speciality, int course, string studCurator)
        {
            Name = name;
            Speciality = speciality;
            Course = course;
            StudCurator = studCurator;
            Students = new List<Student>();
        }

        public bool RemoveStudent(string studentCardNum)
        {
            var student = Students.FirstOrDefault(s => s.StudentCardNum == studentCardNum);
            if (student != null)
            {
                Students.Remove(student);
                student.Dormintory?.RemoveResident(student);
                Console.WriteLine($"Студента {student.Surname} {student.Name} успішно видалено.");
                return true;
            }
            else
            {
                throw new InvalidOperationException("Студента не знайдено.");
                ///return false;
            }
        }

        public string GetAllStudentsInfo()
        {
            if (Students.Count == 0)
                return "There are no students in this group.";

            var sb = new StringBuilder();
            sb.AppendLine($"Students of Group {Name}:");

            foreach (var student in Students)
            {
                sb.AppendLine(student.Fullinfo());
            }

            return sb.ToString();
        }

        public string GroupFullinfo()
        {
            return $"Group {Name}, {Speciality}, Course {Course}, Curator: {StudCurator}, Students: {Students.Count}";
        }


    }
}
