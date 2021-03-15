using System;

namespace Lib.Interfaces
{
    public interface IPerson
    {
        const int maxAge = 100;
        public string _personName { get; set; }
        public int _personAge { get; set; }
        public StatusEnum status { get; set; }
        
        public void GetPersonData()
        {
            Console.WriteLine("\n\tPerson info:"+
                              $"\n\tName - {_personName}"+
                              $"\n\tAge - {_personAge}"+
                              $"\n\tStatus - {status}");
        }
        public int CalculateAgeForLife(int age)
        {
            return maxAge - age;
        }
        
    }

        public enum StatusEnum
        {
            Manager = 1,
            Worker,
            Director
        }

    
}