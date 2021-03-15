using Lib.Interfaces;
using Lib.Models;
namespace Lib.Models
{
    public class DirectorModel:IPerson
    {
        public string _personName { get; set; }
        public int _personAge { get; set; }
        public StatusEnum status { get ; set ; }
        
        public DirectorModel(string name, int age)
        {
            _personAge = age;
            _personName = name;
            status = StatusEnum.Director;
        }
    }
}