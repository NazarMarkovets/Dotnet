
using System;
using Lib.Interfaces;

namespace Lib.Modules
{
    public class PersonModule
    {
        private IPerson _person;
        
        public void InitializePerson(IPerson person)
        {
            _person = person;
        }
        
        
        public void GetAllData()
        {
            Console.WriteLine("I can live:{0}", _person.CalculateAgeForLife(_person._personAge));
            _person.GetPersonData();
        }

    }
}