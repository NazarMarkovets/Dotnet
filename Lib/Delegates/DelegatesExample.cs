using Lib.Models.Persons;

namespace Dotnet.Lib
{
    /// <summary>
    /// Shows delegates usage
    /// </summary>
    public static class DelegatesExample
    {
        public delegate object CreateUserWithPredefinedData();
        public delegate object CreateUserWithSpecialData(string name, int age);
        public static WorkerModel CreateWorkerModel_Stat() => new WorkerModel("Worker Name 1", 30);
        public static ManagerModel CreateManagerModel_Stat() => new ManagerModel("Manager Name 1", 30);
        public static WorkerModel CreateWorkerModelWithParams_Stat(string name, int age) => new WorkerModel(name, age);
        public static ManagerModel CreateManagerModelWithParams_Stat(string name, int age) =>new ManagerModel(name, age);
        
    }
    
}