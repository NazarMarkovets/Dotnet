using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System;
using System.Threading;
using Lib.Async.Factory;

namespace Lib.Async
{
    class MessageBuilder : IInstanceManager
    {
        private readonly Dictionary<string, Message> messageTable = new();
        public void GetHashtable(){
            if(messageTable.Count == 0)
            Console.WriteLine("Table is empty");
            foreach (var key in messageTable.Keys)
            {
                var msg = messageTable[key];
                Console.WriteLine("Table KEY:" + key + " Table VALUE: " + msg.MessageGUID);
            }
        }

        public Dictionary<string, string> DataDictionary => new();
        public void CreateInstance(string KEY)
        {
            lock (messageTable)
            {
                messageTable.Add(KEY,
                    new Message
                    {
                        MessageGUID = Guid.NewGuid(),
                        MessageContent = $"{Thread.CurrentThread.Name}"
                    });
                Console.WriteLine("[Builder Create] "+ 
                                  $"MessageID: {messageTable.Keys.Last()} "+
                                  $"Message content: {messageTable.Values.Last()}");
            }
        }
        public void GetData(string KEY)
        {
            lock (messageTable)
            {
                Console.WriteLine("[Search Key] Name:" + KEY + "...");
                bool removed = messageTable.Remove(KEY);
                Console.ForegroundColor = removed ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine("[Removing Status] " + $"{(removed ? "Success" : "Fail")}");
                Console.ResetColor();
            }
        }
    }



}
