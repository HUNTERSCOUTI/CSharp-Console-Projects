namespace SchoolTaskDataBase;

class Student
 {
#pragma warning disable CS8618
    public int ID; //(Database only) Student ID

    public string Name;

    public int Age;

    public char Gender;

    public string Adress;

    public string EdLine; //Education line ex. "Datatechnician and IT-Support".

    public string Class;

    public List<string> Subjects = new List<string>();

    public override string ToString() => $"\nID: {ID}\nName: {Name} \nAge: {Age} \nGender: {Gender} \nAdress: {Adress} " +
        $"\nEducation Line: {EdLine} \nClass: {Class} \nSubjects: " + String.Join(", ", Subjects) +"\n";
    //Overrides the string that will be displayed and will print it in the way I want it to. Using String interpolation to print it with the variables in it.
}
