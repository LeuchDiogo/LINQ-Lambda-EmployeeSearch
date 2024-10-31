

namespace LINQ_Lambda.Entities
{
    internal class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int YearsWorked { get; set; }

        public int EmployeeAge { get; set; }

        public Employee(string name, string email, double salary, DateTime birthDate, DateTime admissionDate, int yearsworked, int employeeAge)
        {
            Name = name;
            Email = email;
            Salary = salary;
            BirthDate = birthDate;
            AdmissionDate = admissionDate;
            YearsWorked = yearsworked;
            EmployeeAge = employeeAge;
        }
    }
}
