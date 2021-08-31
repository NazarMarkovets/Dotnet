using System;
using System.Reflection;

namespace TraceManager
{
    public class TraceEventArgs
    {
        public string Message{get;}
        private object Obj {get;}
 
        public TraceEventArgs(string mes, Tracing sendObj = null)
        {
            Message = mes;
            Obj = sendObj;
        }
    }
}