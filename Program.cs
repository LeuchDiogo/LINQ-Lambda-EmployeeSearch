using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using LINQ_Lambda.Entities;

namespace LINQ_LAMBDA_employeeSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            Console.Write("Enter the full file path: ");
            string path = Console.ReadLine();

            Console.Write("Search by age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Separate by years of company: ");
            int yearsOfService = int.Parse(Console.ReadLine());

            Console.Write("Search by letter: ");
            char searchLetter = char.Parse(Console.ReadLine().ToUpper());

            Console.Write("Enter the minimum salary (e.g., 1000.00): ");
            double salaryThreshold = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] fields = sr.ReadLine().Split(',');
                        string name = fields[0];
                        string email = fields[1];
                        double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                        DateTime birthDate = DateTime.ParseExact(fields[3], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        DateTime admissionDate = DateTime.ParseExact(fields[4], "yyyy-MM-dd", CultureInfo.InvariantCulture);

                        int yearsWorked = DateTime.Now.Year - admissionDate.Year;
                        if (DateTime.Now < admissionDate.AddYears(yearsWorked)) yearsWorked--;

                        int employeeAge = DateTime.Now.Year - birthDate.Year;
                        if (DateTime.Now < birthDate.AddYears(employeeAge)) employeeAge--;

                        employees.Add(new Employee(name, email, salary, birthDate, admissionDate, yearsWorked, employeeAge));
                    }
                }

                var salarySum = employees
                    .Where(e => e.Name.StartsWith(searchLetter))
                    .Sum(e => e.Salary);

                Console.WriteLine($"Sum of salaries for employees whose name starts with '{searchLetter}': {salarySum.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.WriteLine();

                var highSalaryEmails = employees
                    .Where(e => e.Salary > salaryThreshold)
                    .OrderBy(e => e.Email)
                    .Select(e => e.Email);

                Console.WriteLine($"Emails of employees with salary above {salaryThreshold.ToString("F2", CultureInfo.InvariantCulture)}:");
                foreach (string email in highSalaryEmails) Console.WriteLine(email);

                Console.WriteLine();

                var employeesWithLongService = employees
                    .Where(e => e.YearsWorked > yearsOfService)
                    .OrderBy(e => e.Name)
                    .Select(e => e.Name);

                Console.WriteLine($"Employees with more than {yearsOfService} years of service:");
                foreach (string name in employeesWithLongService) Console.WriteLine(name);

                Console.WriteLine();

                var youngEmployees = employees
                    .Where(e => e.EmployeeAge < age)
                    .OrderBy(e => e.EmployeeAge)
                    .Select(e => e.Name);

                Console.WriteLine($"Employees younger than {age}:");
                foreach (string name in youngEmployees) Console.WriteLine(name);
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while processing the file.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
