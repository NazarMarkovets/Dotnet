using System;
using System.Threading;

namespace Lib.Async
{
    public class Driver
    {

        private readonly int id;
        private ParkingLot _parkingLot;

        public Driver(int id, ParkingLot parkingLot)
        {
            this.id = id;
            this._parkingLot = parkingLot;
        }

        public bool park()
        {
            lock (_parkingLot.key)
            {
                Console.WriteLine("Driver " + id + " is trying to park.");
                bool successfulPark = _parkingLot.decreaseCapacity();
                Console.ForegroundColor = successfulPark ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine("Driver " + id + " parked: " + successfulPark);
                Console.ResetColor();
                Thread.Sleep(2000);
                return successfulPark;
            }
        }
        
        public void sleep()
        {
            Console.WriteLine("Driver " + id + " sleeps");
            Thread.Sleep(new Random().Next(3, 7) * 1000);
        }

        public void wander()
        {
            lock (_parkingLot.key)
            {
                _parkingLot.increaseCapacity();
            }
            Console.WriteLine("Driver " + id + " is wandering around");
            Thread.Sleep(new Random().Next(3, 7) * 1000);
        }

        public void goAway()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Driver " + id + " is going away! :c");
            Console.ResetColor();
        }
    }
}