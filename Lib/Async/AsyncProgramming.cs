using System;
using System.Threading;
using static System.Threading.Thread;

namespace Lib.Async
{
    public static class AsyncProgramming
    {
        private static readonly Object locker = new Object();
        private static volatile int[] array = new int[5];
        private static int counter = 0; // use general scope of memory;

        public static void ThreadLoopWithInfo()
        {
            
            while(counter < array.Length) {
                
                    int localCounter = counter;
                    new Thread(
                        () => {
                            WriteArray(localCounter);
                        }
                    ).Start();
                    counter += 1;
                
            }
            
        }

        private static void WriteArray(int allowedNumber)
        {
            var valueForArray = new Random().Next(20,40);
            Console.WriteLine($"Thread {CurrentThread.ManagedThreadId} waiting...");
            lock (locker)
            {
                System.Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId);
                System.Console.WriteLine("num " + allowedNumber);
                array[allowedNumber] = valueForArray;
            }

        }
    }
}