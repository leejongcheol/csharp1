using System;
class Emp{
    private string name;
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }
}
class EmpTest{
    static void Main()    {
        Emp e = new Emp();
        e.Name = "KIM";
        Console.WriteLine(e.Name);
    }
}