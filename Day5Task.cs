using System;
using System.Collections.Generic;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"Employee ID: {Id}, Name: {Name}";
    }
}

public class Club
{
    private List<Employee> clubMembers = new List<Employee>();

    public void AddInClub(Employee employee)
    {
        clubMembers.Add(employee);
        Console.WriteLine($"{employee.Name} has been added to the club.");
    }
}

public class SocialInsurance
{
    private List<Employee> insuredEmployees = new List<Employee>();

    public void BeginSocialInsurance(Employee employee)
    {
        insuredEmployees.Add(employee);
        Console.WriteLine($"{employee.Name} has been enrolled in social insurance.");
    }
}

public class Company
{
    private List<Employee> employees = new List<Employee>();
    private Club club = new Club();
    private SocialInsurance socialInsurance = new SocialInsurance();

    public void Add(Employee employee)
    {
        employees.Add(employee);
        Console.WriteLine($"{employee.Name} has been added to the company.");

        club.AddInClub(employee);
        socialInsurance.BeginSocialInsurance(employee);
    }

    public void DisplayEmployees()
    {
        Console.WriteLine("Employees in the company:");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Company company = new Company();

        Employee emp1 = new Employee(1, "tina");
        Employee emp2 = new Employee(2, "sherif");

        company.Add(emp1);
        company.Add(emp2);

        Console.WriteLine();
        company.DisplayEmployees();
    }
}
