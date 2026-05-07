using System;
using System.Collections.Generic;
using System.Linq;

public class StudentManager
{
    private List<StudentInventory> students = new List<StudentInventory>();

    public void AddStudents()
    {
        Console.WriteLine("Do you want to add a student? (yes/no)");
        string response = Console.ReadLine().ToLower();

        if (response == "no")
            return;
        else if (response != "yes")
        {
            Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
            AddStudents();
            return;
        }

        StudentInventory student = new StudentInventory();

        student.Name = GetValidName();
        student.Age = GetValidNumber("Enter student age:");
        student.Grade = GetValidNumber("Enter student grade:");

        students.Add(student);
        Console.WriteLine("Student added successfully!\n");

        AddStudents();
    }

    public string GetValidName()
    {
        Console.WriteLine("Enter student name:");
        string name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name) || name.All(char.IsDigit))
        {
            Console.WriteLine("Invalid input. Please enter a valid name.");
            return GetValidName(); 
        }

        return name;
    }

    public int GetValidNumber(string prompt)
    {
        Console.WriteLine(prompt);
        int result;

        if (int.TryParse(Console.ReadLine(), out result))
            return result;

        Console.WriteLine("Invalid input. Please enter a valid number:");
        return GetValidNumber(prompt);
    }

    public void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students were added.");
            return;
        }

        Console.WriteLine("\nDo you want to view all students? (yes/no)");
        if (Console.ReadLine().ToLower() == "yes")
        {
            Console.WriteLine("\nThese are all the students:\n");
            foreach (StudentInventory item in students)
            {
                item.StudentInfo();
            }
        }
    }

    public void CalculateAverage()
    {
        Console.WriteLine("\nDo you want to calculate the average grade? (yes/no)");
        if (Console.ReadLine().ToLower() == "yes")
        {
            double average = students.Average(s => s.Grade.Value);
            Console.WriteLine($"\nAverage Grade: {average:F2}\n");
        }
    }

    public void CheckHighestGrade()
    {
        Console.WriteLine("\nDo you want to check who has the highest grade? (yes/no)");
        if (Console.ReadLine().ToLower() == "yes")
        {
            StudentInventory topStudent = students.OrderByDescending(s => s.Grade).First();
            Console.WriteLine($"\nHighest Grade: {topStudent.Name} with a grade of {topStudent.Grade}\n");
        }
    }

    public void CheckLowestGrade()
    {
        Console.WriteLine("\nDo you want to check who has the lowest grade? (yes/no)");
        if (Console.ReadLine().ToLower() == "yes")
        {
            StudentInventory bottomStudent = students.OrderBy(s => s.Grade).First();
            Console.WriteLine($"\nLowest Grade: {bottomStudent.Name} with a grade of {bottomStudent.Grade}\n");
        }
    }

    public int Count => students.Count;
}