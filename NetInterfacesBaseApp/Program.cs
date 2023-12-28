using System.Collections;

Company company = new() { City = "Moscow", Title = "Yandex" };

Employee bob = new("Bobby", 25, company);
Employee joe = (Employee)bob.Clone();

joe.Company.Title = "Ozon";

Console.WriteLine(bob.Company);
Console.WriteLine(joe.Company);

Company yandex = new() { City = "Moscow", Title = "Yandex" };
Company mail = new() { City = "Moscow", Title = "Mail Group" };
Company piterSoft = new() { City = "St.Peterburg", Title = "Piter Soft" };

Employee[] employees = new Employee[] 
{ 
    new("Sam", 36, yandex),
    new("Bill", 29, piterSoft),
    new("Leo", 41, mail)
};

foreach(var e in employees)
    Console.WriteLine(e);
Console.WriteLine();

Array.Sort(employees);

foreach (var e in employees)
    Console.WriteLine(e);
Console.WriteLine();

//Array.Sort(employees, (a, b) =>
//{
//    return ((Employee)a).Age.CompareTo(((Employee)b).Age);
//});

Array.Sort(employees, new EmployeeAgeComparer());

foreach (var e in employees)
    Console.WriteLine(e);
Console.WriteLine();

class Company
{
    public string? City { get; set; }
    public string? Title { get; set; }

    public override string ToString()
    {
        return $"City: {City}, Title: {Title}";
    }
}

class Employee : ICloneable, IComparable
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public Company Company { get; set; }

    public Employee(string? name, int age, Company company)
    {
        Name = name;
        Age = age;
        Company = company;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Company: {Company}";
    }

    public object Clone()
    {
        //return MemberwiseClone();
        return new Employee(Name, 
                            Age, 
                            new Company()
                            {
                                City = Company.City,
                                Title = Company.Title
                            });
    }

    public int CompareTo(object? obj)
    {
        if (obj is Employee e)
            return this.Name.CompareTo(e.Name);
        else
            throw new ArgumentException("Employe comparer with employee");
    }
}

class EmployeeAgeComparer : IComparer
{
    public int Compare(object? x, object? y)
    {
        if(x is Employee e1 && y is Employee e2)
            return e1.Age.CompareTo(e2.Age);
        else
            throw new ArgumentException("Employe comparer with employee");

    }
}