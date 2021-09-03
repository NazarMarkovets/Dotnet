using System;

namespace Lib.Models.Persons
{
    public class User
    
    {

        public User()
        {
            
        }

        public User(string name, string surname, byte age, double salary, Guid id )
        {
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            Id = id;
        }
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public byte Age { get; init; }
        public double Salary { get; init; }


        private Guid GenerateUUID()
        {
            return Guid.NewGuid();
        }


        public bool Equals(User user)
        {
            return user!=null &&
                   user.Age.Equals(Age) &&
                   user.Name.Equals(Name) &&
                   user.Salary.Equals(Salary) &&
                   user.Surname.Equals(Surname) &&
                   user.Id.Equals(Id);
        }
        
        public User CreateNewRandomUser()
        {
            Random rnd = new();
            
            return new User()
            {
                Name = $"Name {rnd.Next(1, 1000)}",
                Age = (byte)rnd.Next(10, 100),
                Salary = rnd.NextDouble(),
                Surname = $"Surname {rnd.Next(100, 1000)}",
                Id = GenerateUUID()
            };
        }
    }
}