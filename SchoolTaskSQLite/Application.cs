using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SchoolTaskSQLite;

public class Application
{
	private readonly IServiceProvider _serviceProvider;

	public Application(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public void Main()
	{
		Console.Clear();
		Console.Write("Please select what you want to do: \n" +
		              "\n [1] = Add Student\n" +
		              "\n [2] = Update Student\n" +
		              "\n [3] = Remove Student\n" +
		              "\n [4] = Get Student Info\n\n" +
		              "Choice: ");

		int option = int.TryParse(Console.ReadLine(), out var _option) ? _option : 0;

		switch (option)
		{
			case 1:
				Console.Clear();
				AddStudent();
				Console.Clear();
				Main();
				break;
			case 2:
				Console.Clear();
				UpdateStudent();
				Console.Clear();
				Main();
				break;
			case 3:
				Console.Clear();
				RemoveStudent();
				Console.Clear();
				Main();
				break;
			case 4:
				Console.Clear();
				GetStudent();
				Console.Clear();
				Main();
				break;
			default:
				Console.Clear();
				Main();
				break;
		}
	}

	private static bool IsValidString(string s) => s.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));

	public async Task AddStudent()
	{
		//NAME

		var name = InputHelper.GetValidatedString("Enter students name: ", s => IsValidString(s));

		Student student = new Student();
		//AGE
		Console.Write("\nEnter Student Age : ");
		student.Age = int.TryParse(Console.ReadLine(), out var _money) ? _money : 0; 
		//tryparse returns a bool (if it could parse or not) and if true it just returns the var, if false 0.
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
		while (student.Gender != 'M' && student.Gender != 'F')
		{
			Console.Clear();
			Console.Write("Enter Student Name : " + student.Name);
			Console.Write("\n\nEnter Student Age : " + student.Age);
			Console.Write("\n\nEnter Student Gender [M/F] : ");
			student.Gender = Console.ReadKey().KeyChar;
			student.Gender = Char.ToUpper(student.Gender); //Makes sure it's upper case
		}

		//ADRESS
		Console.Write("\n\nEnter Student Adress [Steet, Number, Post, City] : ");
		student.Address = Console.ReadLine();

		//EDUCATION LINE
		student.EdLine = InputHelper.GetValidatedString("Enter Student Education Line: ", s => IsValidString(s));

		//Class
		student.Class = InputHelper.GetValidatedString("Enter Student Class: ", s => IsValidString(s));

		//Subjects
		await using var scope = _serviceProvider.CreateAsyncScope();
		var context = scope.ServiceProvider.GetRequiredService<StudentDbContext>();
		Console.WriteLine("\nEnter Student Subjects [Enter for new subject & end with !] : ");
		var subjects = new List<Subject>();
		string input = string.Empty;
		while (true)
		{
			input = Console.ReadLine();
			if (input == "!")
			{
				break;
			}
			var existingSubject = await context.Subjects.FirstOrDefaultAsync(x => x.Name == input);
			if (existingSubject != null)
			{
				subjects.Add(existingSubject);
			}
			else
			{
				subjects.Add(new Subject()
				{
					Name = input
				}
				);
			}
		}

		student.Subjects = subjects;
		student.Name = name;

		// create student

		context.Students.Add(student);
		await context.SaveChangesAsync();

		Console.WriteLine("Student Added with ID: " + student.ID);
		await Task.Delay(5000);
	}

	private async Task UpdateStudent()
	{
		Console.Write("\nEnter ID of student to update : ");
		int idDetail = Convert.ToInt32(Console.ReadLine());
		Console.Clear();

		await using var scope = _serviceProvider.CreateAsyncScope();
		var context = scope.ServiceProvider.GetRequiredService<StudentDbContext>();

		Console.WriteLine(await context.Students.FirstOrDefaultAsync(x => x.ID == idDetail));
		Console.Write("\nIs this the student [Y/N] : ");
		char sure = Console.ReadKey().KeyChar;
		sure = char.ToUpper(sure);
		if (sure == 'Y')
		{
			Console.Clear();
			var student = await context.Students.FirstOrDefaultAsync(x => x.ID == idDetail);
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
					break;
				case 2:
					student.Age = InputHelper.GetInt("Please enter new Age: ");
					break;
				case 3:
					Console.WriteLine("Please enter new Gender : ");
					student.Gender = Console.ReadKey().KeyChar;
					student.Gender = Char.ToUpper(student.Gender);
					break;
				case 4:
					Console.WriteLine("Please enter new Adress : ");
					student.Address = Console.ReadLine();
					break;
				case 5:
					Console.WriteLine("Please enter new Education Line : ");
					student.EdLine = Console.ReadLine();
					break;
				case 6:
					Console.WriteLine("Please enter new Class : ");
					student.Class = Console.ReadLine();
					break;
				case 7:
					Console.WriteLine("Please enter new Subjects : ");
					List<Subject> update = new();
					while (true)
					{
						string input = Console.ReadLine();
						if (input == "!")
						{
							break;
						}

						var existingSubject = await context.Subjects.FirstOrDefaultAsync(x => x.Name == input);

						if (existingSubject != null)
						{
							update.Add(existingSubject);
						}
						else
						{
							update.Add(new Subject()
							{
								Name = input
							});
						}
					}

					student.Subjects = update;
					break;
				default:
					await UpdateStudent();
					break;
			}

			Console.Clear();
			Console.WriteLine("Student info updated to :");
			Console.WriteLine(student);
			await Task.Delay(2500);

			await context.SaveChangesAsync();
		}
		else
		{
			Console.Clear();
			await UpdateStudent();
		}
	}

	private async Task RemoveStudent()
	{
		int idToDelete = InputHelper.GetInt("Student ID to delete: ");

		await using var scope = _serviceProvider.CreateAsyncScope();
		var context = scope.ServiceProvider.GetRequiredService<StudentDbContext>();

		var studentToDelete = await context.Students.FirstOrDefaultAsync(x => x.ID == idToDelete);

		if (studentToDelete == null)
		{
			Console.WriteLine("No student with that ID found.");
			return;
		}

		Console.WriteLine(studentToDelete);
		Console.Write("Are you sure you want to delete [Y/N] : ");
		char sure = Console.ReadKey().KeyChar;
		sure = Char.ToUpper(sure);
		if (sure == 'Y')
		{
			context.Students.Remove(studentToDelete);
		}

		await context.SaveChangesAsync();
	}

	private async Task GetStudent()
	{
		Console.Write("Enter which detail to search for : \n" +
		              "\n [1] = All\n" +
		              "\n [2] = ID\n" +
		              "\n [3] = Name\n" +
		              "\n [4] = Age\n" +
		              "\n [5] = Gender\n" +
		              "\n [6] = Address\n" +
		              "\n [7] = Education Line\n" +
		              "\n [8] = Subjects\n" +
		              "\nChoice: ");

		int option = int.TryParse(Console.ReadLine(), out var _option) ? _option : 0;

		Console.Clear();

		await using var scope = _serviceProvider.CreateAsyncScope();
		var context = scope.ServiceProvider.GetRequiredService<StudentDbContext>();

		switch (option)
		{
			case 1:
				Console.WriteLine("Press any key to exit.");
				var allStudents = await context.Students.Include(x => x.Subjects).ToListAsync();
				Console.WriteLine(string.Join("\n", allStudents));
				break;
			case 2:
				int idDetail = InputHelper.GetInt("Enter ID: ");
				Console.WriteLine(await context.Students.FirstOrDefaultAsync(x => x.ID == idDetail));
				break;
			case 3:
				Console.Write("\nEnter Name : ");
				string nameDetail = Console.ReadLine();
				Console.WriteLine(await context.Students.FirstOrDefaultAsync(x => x.Name == nameDetail));
				break;
			case 4:
				int ageDetail = InputHelper.GetInt("Enter age: ");
				Console.WriteLine(string.Join("\n ", context.Students.Where(x => x.Age == ageDetail)));
				break;
			case 5:
				Console.Write("\nEnter Gender [M/F] : ");
				char genderDetail = Console.ReadKey().KeyChar;
				genderDetail = Char.ToUpper(genderDetail);
				while (genderDetail != 'M' && genderDetail != 'F')
				{
					Console.Clear();
					Console.Write("\nEnter Gender [M/F] : ");
					genderDetail = Console.ReadKey().KeyChar;
					genderDetail = Char.ToUpper(genderDetail);
				}

				Console.WriteLine("\n" + string.Join("\n ", context.Students.Where(x => x.Gender == genderDetail)));
				break;
			case 6:
				Console.Write("\nEnter Adress : ");
				string adressDetail = Console.ReadLine();
				Console.WriteLine(string.Join("\n ", context.Students.Where(x => x.Address == adressDetail)));
				break;
			case 7:
				Console.Write("\nEnter Education Line : ");
				string edLineDetail = Console.ReadLine();
				Console.WriteLine(string.Join("\n ", context.Students.Where(x => x.EdLine == edLineDetail)));
				if (edLineDetail == null)
				{
					// Log EdLine not found;
					Console.WriteLine("Education Line doesn't exist");
					Console.ReadKey();
					return;
				}
				else
				{
					Console.WriteLine("\nWant to search for specific class? [Y/N] : ");
					char sure = Console.ReadKey().KeyChar;
					sure = Char.ToUpper(sure);
					if (sure == 'Y')
					{
						Console.Clear();
						Console.Write("\nEnter Class : ");
						string classDetail = Console.ReadLine();
						Console.WriteLine(string.Join("\n ", context.Students.Where(x => x.Class == classDetail)));
						if (classDetail == null)
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

				foreach (var student in context.Students.Where(x =>
					         x.Subjects.Any(subj => search.Any(sr => sr == subj.Name))))
				{
					Console.WriteLine(student);
				}

				//var SubjectsToSearchFor = new[] { "Bonusfag, Netværk" };
				//var studentsInSubjects = students.Where(s => SubjectsToSearchFor.All(c => s.Subjects.Contains(c)));
				break;
			default:
				Console.Clear();
				await GetStudent();
				break;
		}

		Console.WriteLine("\n\nPress any key to exit.");
		Console.SetCursorPosition(22, 0);
		Console.ReadKey();
	}
}