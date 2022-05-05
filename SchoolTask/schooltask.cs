using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SchoolTaskDataBase;

class StudentDB
{
    public static List<Student> students = new List<Student>();

    public static void Main()
    {
        Console.Clear();
        Console.Write("Please select what you want to do: \n" +
            "\n [1] = Add Student\n" +
            "\n [2] = Update Student\n" +
            "\n [3] = Remove Student\n" +
            "\n [4] = Get Student Info\n\n" +
            "Choice: ");

        int option = int.TryParse(Console.ReadLine(), out var _option) ? _option : 0;

        if (File.Exists("students.json"))
        {
            Console.WriteLine("Students file found, deserializing it...");
            string fileStr = File.ReadAllText("students.json");
            students = JsonConvert.DeserializeObject<List<Student>>(fileStr);
        }

        switch (option)
        {
            #region cases
            case 1:
                Console.Clear();
                StudentDB.AddStudent();
                Console.Clear();
                StudentDB.Main();
                break;
            case 2:
                Console.Clear();
                StudentDB.UpdateStudent();
                Console.Clear();
                StudentDB.Main();
                break;
            case 3:
                Console.Clear();
                StudentDB.RemoveStudent();
                Console.Clear();
                StudentDB.Main();
                break;
            case 4:
                Console.Clear();
                StudentDB.GetStudent();
                Console.Clear();
                StudentDB.Main();
                break;
            default:
                Console.Clear();
                StudentDB.Main();
                break;
                #endregion
        }
    }

    public static void AddStudent()
    {
        Student student = new Student();

        //NAME
        Console.Write("Enter Students Name : ");
        student.Name = Console.ReadLine();
        #region reset
        foreach (var c in student.Name) // Indexes through it and checks if the numbers 0 to 9 are in there, if so then it restarts
        {
            if (!((int)c - '0' > 9)) // '0' takes ASCII charcters and checks if they are bigger than 9, if so, runs the clear
            {
                Console.Clear();
                StudentDB.AddStudent();
            }
        }
        #endregion
        //AGE
        Console.Write("\nEnter Student Age : ");
        student.Age = int.TryParse(Console.ReadLine(), out var _money) ? _money : 0; //tryparse returns a bool (if it could parse or not) and if true it just returns the var, if false 0.
        #region reset
        while (student.Age == 0)
        {
            Console.Clear();
            Console.Write("Enter Students Name : " + student.Name);
            Console.Write("\n\nEnter Student Age : ");
            student.Age = int.TryParse(Console.ReadLine(), out var _money2) ? _money2 : 0;
        }
        #endregion

        //GENDER
        Console.Write("\nEnter Student Gender [M/F] : ");
        student.Gender = Console.ReadKey().KeyChar;
        student.Gender = Char.ToUpper(student.Gender); //Makes sure it's upper case
        #region reset
        while (student.Gender != 'M' && student.Gender != 'F')
        {
            Console.Clear();
            Console.Write("Enter Student Name : " + student.Name);
            Console.Write("\n\nEnter Student Age : " + student.Age);
            Console.Write("\n\nEnter Student Gender [M/F] : ");
            student.Gender = Console.ReadKey().KeyChar;
            student.Gender = Char.ToUpper(student.Gender); //Makes sure it's upper case
        }
        #endregion

        //ADRESS
        Console.Write("\n\nEnter Student Adress [Steet, Number, Post, City] : ");
        student.Adress = Console.ReadLine();

        //EDUCATION LINE
        Console.Write("\nEnter Student Education Line : ");
        student.EdLine = Console.ReadLine();
        #region reset
        foreach (var c in student.Name) // Indexes through it and checks if the numbers 0 to 9 are in there, if so then it restarts
        {
            if (!((int)c - '0' > 9)) // '0' takes ASCII charcters and checks if they are bigger than 9, if so, runs the clear
            {
                Console.Clear();
                StudentDB.AddStudent();
            }
        }
        #endregion

        Console.Write("\nEnter Student Class : ");
        student.Class = Console.ReadLine();
        #region reset
        foreach (var c in student.Name) // Indexes through it and checks if the numbers 0 to 9 are in there, if so then it restarts
        {
            if (!((int)c - '0' > 9)) // '0' takes ASCII charcters and checks if they are bigger than 9, if so, runs the clear
            {
                Console.Clear();
                StudentDB.AddStudent();
            }
        }
        #endregion

        Console.WriteLine("\nEnter Student Subjects [Enter for new class & end with !] : ");
        string input = string.Empty;
        while (true)
        {
            input = Console.ReadLine();
            if (input == "!")
            {
                break;
            }
            student.Subjects.Add(input);
        }

        student.ID = students.Count + 1;
        students.Add(student);

        string strResultJson = JsonConvert.SerializeObject(students);
        File.WriteAllText(@"students.json", strResultJson);

        Console.WriteLine("Student Added with ID: " + students.Count);
        Thread.Sleep(5000);
    }

    private static void UpdateStudent()
    {
        Console.Write("\nEnter ID of student to update : ");
        int IDDetail = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        Console.WriteLine(string.Join("\n ", students.Where(x => x.ID == IDDetail)));
        Console.Write("\nIs this the student [Y/N] : ");
        char sure = Console.ReadKey().KeyChar;
        sure = char.ToUpper(sure);
        if (sure == 'Y')
        {
            Console.Clear();
            var student = students.FirstOrDefault(x => x.ID == IDDetail);
            if (student == null)
            {
                // Log student not found;
                Console.WriteLine("Student with ID doesn't exist");
                Console.ReadKey();
                return;
            }
            Console.Write("Please select what to update : \n" +
            "\n [1] = Name\n" +
            "\n [2] = Age\n" +
            "\n [3] = Gender\n" +
            "\n [4] = Adress\n" +
            "\n [5] = Education Line\n" +
            "\n [6] = Class\n" +
            "\n [7] = Subjects\n" +
            "\nChoice: ");

            int option = int.TryParse(Console.ReadLine(), out var _option) ? _option : 0;

            Console.Clear();

            switch (option)
            {
                case 1:
                    Console.WriteLine("Please enter new Name : ");
                    student.Name = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Student info updated to :");
                    Console.WriteLine(string.Join("\n ", students.Where(x => x.ID == IDDetail)));
                    Thread.Sleep(2500);
                    break;
                case 2:
                    Console.WriteLine("Please enter new Age : ");
                    student.Age = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Student info updated to :");
                    Console.WriteLine(string.Join("\n ", students.Where(x => x.ID == IDDetail)));
                    Thread.Sleep(2500);
                    break;
                case 3:
                    Console.WriteLine("Please enter new Gender : ");
                    student.Gender = Console.ReadKey().KeyChar;
                    student.Gender = Char.ToUpper(student.Gender);
                    Console.Clear();
                    Console.WriteLine("Student info updated to :");
                    Console.WriteLine(string.Join("\n ", students.Where(x => x.ID == IDDetail)));
                    Thread.Sleep(2500);
                    break;
                case 4:
                    Console.WriteLine("Please enter new Adress : ");
                    student.Adress = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Student info updated to :");
                    Console.WriteLine(string.Join("\n ", students.Where(x => x.ID == IDDetail)));
                    Thread.Sleep(2500);
                    break;
                case 5:
                    Console.WriteLine("Please enter new Education Line : ");
                    student.EdLine = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Student info updated to :");
                    Console.WriteLine(string.Join("\n ", students.Where(x => x.ID == IDDetail)));
                    Thread.Sleep(2500);
                    break;
                case 6:
                    Console.WriteLine("Please enter new Class : ");
                    student.Class = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Student info updated to :");
                    Console.WriteLine(string.Join("\n ", students.Where(x => x.ID == IDDetail)));
                    Thread.Sleep(2500);
                    break;
                case 7:
                    Console.WriteLine("Please enter new Subjects : ");
                    List<string> update = new();
                    while (true)
                    {
                        string input = Console.ReadLine();
                        if (input == "!")
                        {
                            break;
                        }
                        update.Add(input);
                    }
                    student.Subjects = update;
                    Console.Clear();
                    Console.WriteLine("Student info updated to :");
                    Console.WriteLine(string.Join("\n ", students.Where(x => x.ID == IDDetail)));
                    Thread.Sleep(2500);
                    break;
                default:
                    StudentDB.UpdateStudent();
                    break;
            }
            string strResultJson = JsonConvert.SerializeObject(students);
            File.WriteAllText(@"students.json", strResultJson);
        }
        else
        {
            Console.Clear();
            StudentDB.UpdateStudent();
        }
    } // FINISHED

    private static void RemoveStudent()
    {
        Console.Write("Student ID to delete : ");
        int delete = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(students.SingleOrDefault(x => x.ID == delete));
        Console.Write("Are you sure you want to delete [Y/N] : ");
        char sure = Console.ReadKey().KeyChar;
        sure = Char.ToUpper(sure);
        if (sure == 'Y')
        {
            Student studentToDelete = students.SingleOrDefault(x => x.ID == delete);
            students.Remove(studentToDelete);
            foreach (Student student in students)
            {
                if (student.ID > delete) student.ID--;
            }
        }
        else
        {
            Console.Clear();
            StudentDB.Main();
        }
        string strResultJson = JsonConvert.SerializeObject(students);
        File.WriteAllText(@"students.json", strResultJson);
    }

    private static void GetStudent()
    {
        Console.Write("Enter which detail to serch for : \n" +
            "\n [1] = All\n" +
            "\n [2] = ID\n" +
            "\n [3] = Name\n" +
            "\n [4] = Age\n" +
            "\n [5] = Gender\n" +
            "\n [6] = Adress\n" +
            "\n [7] = Education Line\n" +
            "\n [8] = Subjects\n" +
            "\nChoice: ");

        int option = int.TryParse(Console.ReadLine(), out var _option) ? _option : 0;

        Console.Clear();

        switch (option)
        {
            case 1:
                Console.WriteLine("Press any key to exit.");
                Console.WriteLine(string.Join("\n", students));
                break;
            case 2:
                Console.Write("\nEnter ID : ");
                int IDDetail = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(string.Join("\n ", students.Where(x => x.ID == IDDetail)));
                break;
            case 3:
                Console.Write("\nEnter Name : ");
                string NameDetail = Console.ReadLine();
                Console.WriteLine(string.Join("\n ", students.Where(x => x.Name == NameDetail)));
                break;
            case 4:
                Console.Write("\nEnter Age : ");
                int AgeDetail = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(string.Join("\n ", students.Where(x => x.Age == AgeDetail)));
                break;
            case 5:
                Console.Write("\nEnter Gender [M/F] : ");
                char GenderDetail = Console.ReadKey().KeyChar;
                GenderDetail = Char.ToUpper(GenderDetail);
                while (GenderDetail != 'M' && GenderDetail != 'F')
                {
                    Console.Clear();
                    Console.Write("\nEnter Gender [M/F] : ");
                    GenderDetail = Console.ReadKey().KeyChar;
                    GenderDetail = Char.ToUpper(GenderDetail);
                }
                Console.WriteLine("\n" + string.Join("\n ", students.Where(x => x.Gender == GenderDetail)));
                break;
            case 6:
                Console.Write("\nEnter Adress : ");
                string AdressDetail = Console.ReadLine();
                Console.WriteLine(string.Join("\n ", students.Where(x => x.Adress == AdressDetail)));
                break;
            case 7:
                Console.Write("\nEnter Education Line : ");
                string EdLineDetail = Console.ReadLine();
                Console.WriteLine(string.Join("\n ", students.Where(x => x.EdLine == EdLineDetail)));
                if (EdLineDetail == null)
                {
                    // Log EdLine not found;
                    Console.WriteLine("Education Line doesn't exist");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("\nWant to search for specifc class? [Y/N] : ");
                    char sure = Console.ReadKey().KeyChar;
                    sure = Char.ToUpper(sure);
                    if (sure == 'Y')
                    {
                        Console.Clear();
                        Console.Write("\nEnter Class : ");
                        string ClassDetail = Console.ReadLine();
                        Console.WriteLine(string.Join("\n ", students.Where(x => x.Class == ClassDetail)));
                        if (ClassDetail == null)
                        {
                            // Log Class not found;
                            Console.WriteLine("Class doesn't exist");
                            Console.ReadKey();
                            return;
                        }

                    }
                    else
                    {
                        Console.Clear();
                        return;
                    }
                    break;
                }
            case 8:
                Console.Write("\nEnter Subjects [End with !] : \n");
                List<string> search = new();
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "!")
                    {
                        break;
                    }
                    search.Add(input);
                }
                foreach (var student in students.Where(x => x.Subjects.Any(cl => search.Any(sr => sr == cl))))
                {
                    Console.WriteLine(student);
                }
                //var SubjectsToSearchFor = new[] { "Bonusfag, Netværk" };
                //var studentsInSubjects = students.Where(s => SubjectsToSearchFor.All(c => s.Subjects.Contains(c)));
                break;
            default:
                Console.Clear();
                StudentDB.GetStudent();
                break;
        }
        Console.WriteLine("\n\nPress any key to exit.");
        Console.SetCursorPosition(22, 0);
        Console.ReadKey();
    }
}
