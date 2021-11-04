using System.Runtime.CompilerServices;

namespace Lib.Async
{
    public class ParkingLot
    {
        private int capacity = 7;
        private int freeCapacity = 0;

        public object key = new object();

        public ParkingLot()
        {
            this.freeCapacity = capacity;
        }

        public bool decreaseCapacity()
        {
            lock (key)
            {
                if (freeCapacity > 0)
                {
                    freeCapacity -= 1;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void increaseCapacity()
        {
            lock (key)
            {
                freeCapacity += 1;
            }
        }
    }
}