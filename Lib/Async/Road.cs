using System;
using System.Threading;
using Dotnet.Lib;

namespace Lib.Async
{
    public class Road
    {
        public void Run(object direction, string directionName) 
        {
            while (true)
            {
                lock (TrafficLight.direction)
                {
                    if (TrafficLight.direction.Equals(direction))
                    {
                        Console.WriteLine("cars are going " + directionName);
                        Thread.Sleep(1000);
                    }
                }
            }
        }
    }
}