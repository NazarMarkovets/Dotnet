using System;
using Lib.Interfaces;
using static System.Console;

namespace Lib.Models
{
    public class DirectorModel:IPerson
    {
        public string _personName { get; set; }
        public int _personAge { get; set; }
        public StatusEnum status { get ; set ; }

        public DirectorModel() => status = StatusEnum.Director;
        
        public void GetAge()
        {
            WriteLine($"I'm your {status}. I don't want to say my age.");
        }

        public void SetPersonalData()
        {
            WriteLine("Write name for a director:");
            _personName = ReadLine();
            WriteLine("Write age for a director ");
            _personAge = int.Parse(ReadLine() ?? throw new InvalidOperationException());
        }

    }
}