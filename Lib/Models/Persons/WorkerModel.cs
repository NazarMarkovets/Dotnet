using System;
using Lib.Interfaces;

namespace Lib.Models.Persons
{
    public class WorkerModel: IPerson
    {
        public string _personName { get; set; }
        public int _personAge { get; set; }
        public StatusEnum status { get; set; }

        public WorkerModel(string name, int age)
        {
            _personAge = age;
            _personName = name;
            status = StatusEnum.Worker;
        }
        
        private int WorkDay { get; set; }

        public virtual void MakeWork()
        {
            Console.WriteLine($"I am a {status} and do my work for {WorkDay}");
        }

        
    }
}