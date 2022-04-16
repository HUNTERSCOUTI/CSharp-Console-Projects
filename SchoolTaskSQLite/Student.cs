namespace SchoolTaskSQLite;

public class Student
{
	public int ID { get; set; } //(Database only) Student ID

	public string Name { get; set; }

	public int Age { get; set; }

	public char Gender { get; set; }

	public string Address { get; set; }

	public string EdLine { get; set; }

	public string Class { get; set; }

	public virtual ICollection<Subject> Subjects { get; set; }

	public override string ToString() => $"\nID: {ID}\nName: {Name} \nAge: {Age} \nGender: {Gender} \nAddress: {Address} \nEducation Line: {EdLine} \nClass: {Class} \nSubjects: " + String.Join(", ", Subjects) +"\n";
}

public class Subject
{
	public int Id { get; set; }
	public string Name { get; set; }

	public override string ToString()
	{
		return Name;
	}
}