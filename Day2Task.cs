using System;

public struct HiringDate
{
    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }

    public HiringDate(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public override string ToString()
    {
        return $"{Day}/{Month}/{Year}";
    }
}

public class Employee
{
    public int ID { get; set; }
    public double Salary { get; set; }
    public HiringDate HireDate { get; set; }
    public string Gender { get; set; }

    public Employee(int id, double salary, HiringDate hireDate, string gender)
    {
        ID = id;
        Salary = salary;
        HireDate = hireDate;
        Gender = gender;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Salary: {Salary}, Hire Date: {HireDate}, Gender: {Gender}";
    }
}

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Console.Write("Enter the number of employees: ");
        int size = int.Parse(Console.ReadLine());

        Employee[] employees = new Employee[size];

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"\nEnter details for Employee {i + 1}:");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Salary: ");
            double salary = double.Parse(Console.ReadLine());

            Console.Write("Hire Date (day): ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Hire Date (month): ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Hire Date (year): ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            HiringDate hireDate = new HiringDate(day, month, year);

            employees[i] = new Employee(id, salary, hireDate, gender);
        }

        Array.Sort(employees, (e1, e2) => 
        {
            DateTime date1 = new DateTime(e1.HireDate.Year, e1.HireDate.Month, e1.HireDate.Day);
            DateTime date2 = new DateTime(e2.HireDate.Year, e2.HireDate.Month, e2.HireDate.Day);
            return date1.CompareTo(date2);
        });
        
        Console.WriteLine("\nSorted Employees by Hire Date:");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}
