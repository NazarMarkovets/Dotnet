using System;

namespace Lib.AbstractClassUsage
{
    /// <summary>
    /// Some Usual Worker 
    /// </summary>
    public class UsualWorker: Person
    {
        public override void ShowAge()
        {
            Console.WriteLine($"Usual Worker: Override abstract Method: Age - {Age}");
        }


        public UsualWorker(decimal salary) : base(salary)
        {
        }
    }
}