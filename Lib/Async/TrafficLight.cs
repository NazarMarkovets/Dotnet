using System;
using System.Threading;

namespace Lib.Async
{
    class TrafficLight
    {
        public static readonly object EAST = new object();
        public static readonly object WEST = new object();
        public static readonly object NORTH = new object();
        public static readonly object SOUTH = new object();

        public static object direction = EAST;
        public void Run()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                AllowEast();
                AllowNorth();
                AllowSouth();
                AllowWest();
            }
        }

        private void AllowNorth()
        {
            lock (direction)
            {
                direction = NORTH;
                Console.WriteLine("allow north");
                Thread.Sleep(5000);
            }
        }

        private void AllowSouth()
        {
            lock (direction)
            {
                direction = SOUTH;

                Console.WriteLine("allow south");
                Thread.Sleep(5000);
            }
        }

        private void AllowEast()
        {
            lock (direction)
            {
                direction = EAST;
                Console.WriteLine("allow east");
                Thread.Sleep(5000);
            }
        }

        private void AllowWest()
        {
            lock (direction)
            {
                direction = WEST;
                Console.WriteLine("allow west");
                Thread.Sleep(5000);
            }
        }
    }
}