using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Collections;

namespace Lib.Async
{
    public class ThreadSync
    {
        private readonly MessageBuilder messageBuilder = new MessageBuilder();
        private Reader GetReader => new(messageBuilder);
        private Creator GetCreator => new(messageBuilder);
        /// <summary>
        ///  Task 2
        /// </summary>
        public void SyncCreatingReadingMessages()
        {
            List<Thread> listOfThreads = new List<Thread>();
            listOfThreads.AddRange(new Thread[]{
                new Thread(()=>GetCreator.CreateMessage("Asus")),
                new Thread(()=>GetCreator.CreateMessage("HP")),
                new Thread(()=>GetCreator.CreateMessage("Dell")),
                new Thread(()=>GetCreator.CreateMessage("PS")),
                new Thread(()=>GetCreator.CreateMessage("MB")),
                
                new Thread(()=>GetReader.ReadMessage("Asus")),
                new Thread(()=>GetReader.ReadMessage("HP")),
                new Thread(()=>GetReader.ReadMessage("Dell")),
                new Thread(()=>GetReader.ReadMessage("PS")),
                new Thread(()=>GetReader.ReadMessage("MB"))
            });
            
            foreach (var item in listOfThreads)
            {
                item.Start();
            }
            
            foreach (var item in listOfThreads)
            {
                item.Join();
            }

            messageBuilder.GetHashtable();
        }
        
        public void SyncTraficLightsWork()
        {
            TrafficLight trafficLight = new TrafficLight();
            
            var east = new Road();
            var west = new Road();
            var north = new Road();
            var south = new Road();

            Thread trafficLightThread = new Thread(trafficLight.Run);
            trafficLightThread.Start();
            
            new Thread(() => east.Run(TrafficLight.EAST, nameof(east))).Start();
            new Thread(() => west.Run(TrafficLight.WEST, nameof(west))).Start();
            new Thread(() => south.Run(TrafficLight.SOUTH, nameof(south))).Start();
            new Thread(() => north.Run(TrafficLight.NORTH, nameof(north))).Start();
            
            Thread.Sleep(40000);
            trafficLightThread.Interrupt();
        }

        public void SyncParkingLot()
        {
            var parkingLot = new ParkingLot();
            
            int id = 0;

            while (true)
            {
                id += 1;
                var driver = new Driver(id, parkingLot);
                
                Thread.Sleep(1 * 1000);

                new Thread(() =>
                {
                    bool succeeded = driver.park();

                    while (succeeded)
                    {
                        driver.sleep();
                        driver.wander();
                        succeeded = driver.park();
                    }

                    driver.goAway();
                }).Start();
            }

        }
    }
}
