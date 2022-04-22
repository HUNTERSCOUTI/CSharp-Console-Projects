namespace SchoolTaskDataBase;

class Student
 {
    #pragma warning disable CS8618
    public int ID { get; set; } //(Database only) Student ID

    public string Name { get; set; }

    public int Age { get; set; }

    public char Gender { get; set; }

    public string Adress { get; set; }

    public string EdLine { get; set; } //Education line ex. "Datatechnician and IT-Support".

    public string Class { get; set; }

    public List<string> Subjects { get; set; } = new List<string>();

    public override string ToString() => $"\nID: {ID}\nName: {Name} \nAge: {Age} \nGender: {Gender} \nAdress: {Adress} \nEducation Line: {EdLine} \nClass: {Class} \nSubjects: " + String.Join(", ", Subjects) +"\n";
    //Overrides the string that will be displayed and will print it in the way I want it to. Using String interpolation to print it with the variables in it.
}
