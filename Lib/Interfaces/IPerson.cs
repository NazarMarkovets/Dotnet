using System.IO;
using System;
using Lib.Models;

namespace Lib.Interfaces
{
    public interface IPerson
    {
        const int maxAge = 100;
        public string _personName { get; set; }
        public int _personAge { get; set; }
        public StatusEnum status { get; set; }

        public void GetAge()
        {
            Console.WriteLine("Person age:{0}", _personAge);   
        }
        public void SetPersonalData();

        public void GetPersonData()
        {
            Console.WriteLine("\n\tDirector info:" +
                              $"\n\tName - {_personName}" +
                              $"\n\tAge - {_personAge}" +
                              $"\n\tStatus - {status}");
        }
        public int CalculateAgeForLife(int age)
        {
            return maxAge - age;
        }

        public string ReturnPersonName()
        {
            return _personName;
        }
    }

        public enum StatusEnum
        {
            Manager = 1,
            Worker,
            Director
        }

    
}