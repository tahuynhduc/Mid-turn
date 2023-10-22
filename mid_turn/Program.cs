using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static mid_turn.Program;

namespace mid_turn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestStudent testStudent = new TestStudent();
            var i = 0;
            while (i < 100)
            {
                testStudent.ChooseFunction();
                var test = int.Parse(Console.ReadLine());
                switch (test)
                {
                    case 1:
                        Console.WriteLine($"Please Input info");
                        Console.WriteLine("ID:");
                        var id = int.Parse(Console.ReadLine());
                        Console.WriteLine("Name:");
                        var name = Console.ReadLine();
                        Console.WriteLine("Gender:");
                        var gender = Console.ReadLine();
                        Console.WriteLine("age:");
                        var age = int.Parse(Console.ReadLine());
                        Console.WriteLine("birthday:");
                        var birthday = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Class:");
                        var clas = Console.ReadLine();
                        Console.WriteLine("MarkAVG:");
                        var mark1 = float.Parse(Console.ReadLine());
                        var mark2 = float.Parse(Console.ReadLine());
                        var mark3 = float.Parse(Console.ReadLine());
                        testStudent.AddStudent(id, name, gender, age, birthday, clas, mark1, mark2, mark3);
                        Console.WriteLine($"Finish add data student");
                        break;
                    case 2:
                        Console.WriteLine($"Data After Arrange");
                        testStudent.ShowInforStudent();
                        break;
                    case 3:
                        Console.WriteLine($"Data Student");
                        testStudent.ShowInforStudent();
                        break;
                    case 4:
                        Console.WriteLine("Input name you want find");
                        var findName = Console.ReadLine();
                        testStudent.FindStudent(findName);
                        break;
                    case 5:
                        Console.WriteLine("Input id you want remove");
                        var removeStudentById = int.Parse(Console.ReadLine());
                        testStudent.RemoveStudentByID(removeStudentById);
                        break;
                    case 6:
                        return;
                }
            }
        }
        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public DateTime Birthday { get; set; }
            public string Class { get; set; }
            public float Mark1 { get; set; }
            public float Mark2 { get; set; }
            public float Mark3 { get; set; }
            public float MarkAVG()
            {
                return (Mark1 + Mark2 + Mark3) / 3;
            }
            public void ShowInfo()
            {
                Console.WriteLine($"Id:{Id}");
                Console.WriteLine($"Name:{Name}");
                Console.WriteLine($"Gender:{Gender}");
                Console.WriteLine($"Age:{Age}");
                Console.WriteLine($"Birthday:{Birthday}");
                Console.WriteLine($"Class:{Class}");
                Console.WriteLine($"MarkAVG:{MarkAVG()}");
            }
            public void AddInfo(int id, string name, string gender, int age, DateTime birthday, string clas, float mark1, float mark2, float mark3)
            {
                Mark1 = mark1;
                Mark2 = mark2;
                Mark3 = mark3;
                Name = name;
                Gender = gender;
                Id = id;
                Age = age;
                Birthday = birthday;
                Class = clas;
            }
        }
        public class TestStudent
        {
            List<Student> students = new List<Student>();
            Student student
            public void AddStudent(int id, string name, string gender, int age, DateTime birthday, string clas, float mark1, float mark2, float mark3)
            {
                student = new Student();
                student.AddInfo(id, name, gender, age, birthday, clas, mark1, mark2, mark3);
                ArrangeStudentWithMarkAVG();
            }
            public void FindStudent(string studentName)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Name == studentName)
                    {
                        students[i].ShowInfo();
                    }
                }
            }
            public void RemoveStudentByID(int studentId)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].Id == studentId)
                    {
                        students.RemoveAt(i);
                    }
                }
            }
            public void ShowInforStudent()
            {
                for (int i = 0; i < students.Count; i++)
                {
                    students[i].ShowInfo();
                }
            }
            public void ArrangeStudentWithMarkAVG()
            {
                var markavs = student.MarkAVG();
                if (!students.Contains(student))
                {
                    students.Add(student);
                    return;
                }
                for (int i = 0; i < students.Count; i++)
                {
                    if (markavs > students[i].MarkAVG())
                    {
                        Console.WriteLine("test");
                        students.AddRange(student);
                    }
                }
            }
            public void ChooseFunction()
            {
                Console.WriteLine();
                Console.WriteLine($"Please select an option:");
                Console.WriteLine($"======================================================");
                Console.WriteLine($"1. Input information (input details for a student)");
                Console.WriteLine($"2. Sorting student asccending by average mark");
                Console.WriteLine($"3. Display all the student.");
                Console.WriteLine($"4. Search Student by Name");
                Console.WriteLine($"5. Delete Student by student ID.");
                Console.WriteLine($"6. Exit program.");
                Console.WriteLine($"=======================================================");
                Console.WriteLine("Select Function");
            }
        }
    }
}
