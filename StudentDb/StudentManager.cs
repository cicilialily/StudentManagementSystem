using System;
using System.Collections.Generic;
using System.Linq;

public class StudentManager
{
    private List<StudentInventory> students = new List<StudentInventory>();

    public void Run()
    {
        Console.WriteLine("\n===== Student Manager =====");
        Console.WriteLine("0 - Add a student");
        Console.WriteLine("1 - View all students");
        Console.WriteLine("2 - Calculate average grade");
        Console.WriteLine("3 - Check highest grade");
        Console.WriteLine("4 - Check lowest grade");
        Console.WriteLine("5 - Exit");
        Console.WriteLine("===========================");
        Console.Write("Pick an option from (0-5): ");

        string input = Console.ReadLine();

        switch (input)
        {
            case "0": AddStudent();        break;
            case "1": ViewStudents();      break;
            case "2": CalculateAverage();  break;
            case "3": CheckHighestGrade(); break;
            case "4": CheckLowestGrade();  break;
            case "5":
                Console.WriteLine("That is all");
                return;
            default:
                Console.WriteLine("Invalid option. Please pick a number between 0 and 5.");
                break;
        }

        Run();
    }

    public void AddStudent()
    {
        StudentInventory student = new StudentInventory();

        student.Name  = GetValidName();
        student.Age   = GetValidNumber("Enter student age:");
        student.Grade = GetValidNumber("Enter student grade:");

        students.Add(student);
        Console.WriteLine("Student added successfully!");
    }

    public void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students have been added yet.");
            return;
        }

        Console.WriteLine("\nAll students:\n");
        foreach (StudentInventory item in students)
        {
            item.StudentInfo();
        }
    }

    public void CalculateAverage()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students to calculate average for.");
            return;
        }

        double average = students.Average(s => s.Grade.Value);
        Console.WriteLine($"\nAverage Grade: {average:F2}");
    }

    public void CheckHighestGrade()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students to check.");
            return;
        }

        StudentInventory top = students.OrderByDescending(s => s.Grade).First();
        Console.WriteLine($"\nHighest Grade: {top.Name} with a grade of {top.Grade}");
    }

    public void CheckLowestGrade()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students to check.");
            return;
        }

        StudentInventory bottom = students.OrderBy(s => s.Grade).First();
        Console.WriteLine($"\nLowest Grade: {bottom.Name} with a grade of {bottom.Grade}");
    }

    private string GetValidName()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name) || name.All(char.IsDigit))
        {
            Console.WriteLine("Invalid input. Please enter a valid name.");
            return GetValidName();
        }

        return name;
    }

    private int GetValidNumber(string change)
    {
        Console.Write(change + " ");
        int result;

        if (int.TryParse(Console.ReadLine(), out result))
            return result;

        Console.WriteLine("Invalid input. Please enter a valid number.");
        return GetValidNumber(change);
    }

    public int Count => students.Count;
}
