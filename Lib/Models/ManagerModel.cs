using System;
using Lib.Interfaces;

namespace Lib.Models
{
    public class ManagerModel : IPerson
    {
        public string _personName { get;set;}
        public int _personAge { get; set;}
        public StatusEnum status { get; set; }

        public ManagerModel() => status = StatusEnum.Manager;

        public void GetAge()
        {
            Console.WriteLine("My age is: {0}", _personAge);
        }

        public void SetPersonalData()
        {
            Console.WriteLine("Write name for a manager:");
            _personName = Console.ReadLine();
            Console.WriteLine("Write age for a manager ");
            _personAge = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        }

        public void GetPersonData()
        {
            Console.WriteLine($"I am a {status}, I can not to say my name");
        }
        


    }
}