using System;

public class StudentInventory
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public int? Grade { get; set; }

    public void StudentInfo()
    {
        Console.WriteLine("Name: " + Name);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Grade: " + Grade);
        Console.WriteLine();
    }
} 