using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading.Channels;

namespace TraceManager
{
    public class Tracing
    {
        private readonly List<string> EventsList;

        public Tracing()
        {
            TraceON += Display;
            EventsList = new List<string>();
        }
        public void ShowInfo(object type)
        {
            Notify?.Invoke(this,new TraceEventArgs("ShowInfo"));
            Console.WriteLine(GetObjectType(type)?? "Can't check type");
            EventsList.ForEach(Console.WriteLine);
        }

        public string GetObjectType(object type)
        {
            Notify?.Invoke(this,new TraceEventArgs("Try get type"));
            return type switch
            {
                ICollection @collection => "Created Collection" + nameof(type) + @collection.GetType(),
                Delegate @delegate => "Created Delegate" + nameof(type) + @delegate.Method + @delegate.Target + @delegate.GetMethodInfo(),
                int integer => "Created integer" + nameof(type) + integer,
                _ => null
            };
        }
        public void AddToTracing(object counter, Delegate @delegate)
        {
            EventsList.Add($"Item#{counter}\nDelegateName: {@delegate}\nMethodName: {@delegate.Method.Name}\nTarget: {@delegate.Target}");
        }
        
        public delegate void TraceHandler(object sender, TraceEventArgs e);
        public event TraceHandler Notify;
        public event TraceHandler TraceON
        {
            add => Console.WriteLine($"\t####{value.Method.Name} Event created####\n");
            remove => Console.WriteLine($"\t####{value.Method.Name} Event deleted####\n");
        }
        public static void Display(object sender, TraceEventArgs e) =>
            Console.WriteLine($"## Display Method: Sender {sender.ToString()}: Event message: " + e.Message);
        private enum STATE
        {
            INIT = 1,
            PROCESS = 2,
            CANSEL = 3
        }

        public static void OnTraceOn(object sender, TraceEventArgs e) => Console.WriteLine(e.Message);
    }
    
}