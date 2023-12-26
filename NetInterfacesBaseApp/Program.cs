Company company = new() { City = "Moscow", Title = "Yandex" };

Employee bob = new("Bobby", 25, company);
Employee joe = (Employee)bob.Clone();

joe.Company.Title = "Ozon";

Console.WriteLine(bob.Company);
Console.WriteLine(joe.Company);


class Company
{
    public string? City { get; set; }
    public string? Title { get; set; }

    public override string ToString()
    {
        return $"City: {City}, Title: {Title}";
    }
}

class Employee : ICloneable
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
}