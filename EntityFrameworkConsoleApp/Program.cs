using EntityFramework.Data;
using EntityFramework.Data.Entities;


public class program
{
    public static void Main()
    {
        Console.WriteLine("Insert Employee");

        CRUDManager obj = new CRUDManager();
        Console.WriteLine("Enter EMP");
        var naam = Console.ReadLine();
        var addr = Console.ReadLine();
        obj.Insert(new Employee { Name = naam, Address = addr });
        PrintAllEmployees();
        
    }

    private static void PrintAllEmployees()
    {
        Console.WriteLine("Printing All Employees");
        CRUDManager obj = new CRUDManager();
        foreach(Employee employee in obj.GetAllEmployees())
        {
            Console.WriteLine($"Employee Name is {employee.Name} and address is {employee.Address}");
        }
    }
}