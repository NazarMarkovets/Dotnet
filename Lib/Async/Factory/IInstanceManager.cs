using System;

namespace Lib.Async.Factory
{
    public interface IInstanceManager
    {
        public void CreateInstance(string KEY);
        
        public void GetData(string KEY);
    }
}