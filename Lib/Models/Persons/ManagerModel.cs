using Lib.Interfaces;

namespace Lib.Models.Persons
{
    public class ManagerModel : IPerson
    {
        public string _personName { get;set;}
        public int _personAge { get; set; }

        public StatusEnum status { get; set; }

        public ManagerModel(string name, int age)
        {
            _personAge = age;
            _personName = name;
            status = StatusEnum.Manager;
        }
        
    }
}