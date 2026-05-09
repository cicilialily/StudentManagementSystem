public class Program
{
    public static void Main(string[] args)
    {
        StudentManager manager = new StudentManager();

        manager.Run();

        if (manager.Count == 0)
        {
            Console.WriteLine("No students were added.");
            Console.ReadKey();
            return;
        }

        manager.ViewStudents();
        manager.CalculateAverage();
        manager.CheckHighestGrade();
        manager.CheckLowestGrade();

        Console.WriteLine("\nPress any key to exit");
        Console.ReadKey();
    }
}
