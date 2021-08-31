using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace TraceManager
{
    public class Tracing
    {
        public void ShowInfo(object type)
        {
            Notify?.Invoke(this,new TraceEventArgs("ShowInfo"));
            Console.WriteLine(GetObjectType(type)?? "Can't check type");
        }
        private string GetObjectType(object type)
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

        public delegate void TraceHandler(object sender, TraceEventArgs e);
        public event TraceHandler Notify;

        // public static IEnumerable<Type> NextGalaxy
        // {
        //     get
        //     {
        //         yield return typeof(T);
        //         yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
        //         yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
        //         yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
        //     }
        // }
        
        // public delegate void TracingManager(object sender, TraceEventArgs e);
        // public event TracingManager TraceOn
        // {
        //     add { 
        //         TraceOn += value;
        //         Console.WriteLine($"{value.Method.Name} created");
        //     }
        //     remove
        //     {
        //         TraceOn -= value; 
        //         Console.WriteLine($"{value.Method.Name} deleted");
        //     }
        // }

        public event TraceHandler TraceOFF
        {
            add { 
                TraceOFF += value;
                    Console.WriteLine($"{value.Method.Name} created");
                }
                remove
                {
                    TraceOFF -= value; 
                    Console.WriteLine($"{value.Method.Name} deleted");
                }
        }

        private enum STATE
        {
            INIT = 1,
            PROCESS = 2,
            CANSEL = 3
        }
    }
    
}