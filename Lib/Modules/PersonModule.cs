using System;
using Lib.Interfaces;

namespace Lib.Modules
{
    public class PersonModule
    {
        private IPerson _person;
        
        public void InitializePerson(IPerson person)
        {
            _person = person?? throw new NullReferenceException("Given object == null");
        }
        
        public void GetAllData()
        {
            Console.WriteLine("\nI can live:{0}", _person.CalculateAgeForLife(_person._personAge));
            _person.GetPersonData();
        }

    }
}