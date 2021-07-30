using System;

namespace Lib.AbstractClassUsage
{
    /// <summary>
    /// Class force for creating ctor
    /// Class not allow and not allow to edit some methods
    /// </summary>
    public abstract class Person
    {
        private decimal Salary { get; }
        protected Person(decimal salary)
        {
            Salary = salary;
        }

        

        public int Age { get; set; } = 650;
        public abstract void ShowAge();

        /// <summary>
        /// <remarks>Must be overriden</remarks>
        /// <value>I have no category</value>
        /// </summary>
        public virtual void ShowCategory()
        {
            Console.WriteLine("I have no category");
        }

        /// <summary>
        /// Can't be accessible for editing
        /// <example>person.Age = 30</example>
        /// <returns>Age: 650 default</returns>
        /// </summary>
        public void ShowAgeNotAbstract()
        {
            Console.WriteLine($"[Not Accessible to edit] ShowAgeNotAbstract :{Age}");
        }

        public void ShowPersonSalary(double salary)
        {
            Console.WriteLine($"[Not Accessible to edit] ShowPersonSalary : {salary}$");
            
        }
        public void ShowPersonSalary()
        {
            Console.WriteLine($"[Not Accessible to edit] ShowPersonSalary within params{Salary}$");
            
        }

        public decimal GetPersentsOfSalary()
        {
            return Salary / 100 * new Random().Next(0, 100);
        }
    }
}