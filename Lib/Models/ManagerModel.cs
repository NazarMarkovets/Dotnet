using System;
using Lib.Interfaces;

namespace Lib.Models
{
    public class ManagerModel : IPerson
    {
        public string _personName { get;set;}
        private int age;
        public int _personAge 
        {
            get
            {
                Console.WriteLine("My age is: {0}", age);
                return age;
            }
            set => age = value;
        }
        public StatusEnum status { get; set; }

        public ManagerModel(string name, int age)
        {
            _personAge = age;
            _personName = name;
            status = StatusEnum.Manager;
        }
        
    }
}