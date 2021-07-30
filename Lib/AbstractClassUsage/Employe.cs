using System;

namespace Lib.AbstractClassUsage
{
    public sealed class Employer: Person
    {
        private int EmpCode { get; set; }
        private string WorkerCategory { get; }
        public Employer(string workerCategory, decimal salary) : base(salary)
        {
            WorkerCategory = workerCategory;
            EmpCode = GetHashCode();
        }
        public override void ShowAge()
        {
            Console.WriteLine($"Employer {EmpCode}: Overrided abstract Method: Age - {Age}");
        }

        public void ShowCatagory()
        {
            Console.WriteLine($"Employer {EmpCode}: Category - {WorkerCategory}");
        }

        public override void ShowCategory()
        {
            Console.WriteLine($"Employer {EmpCode} Category: {WorkerCategory}");
        }
    }
}