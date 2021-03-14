
using System;
using Lib.Interfaces;
using Lib.Models;

namespace Lib.Modules
{
    public class PersonModule<T>
    {
        private IPerson _person;
        
        public void InitializePerson(T ob)
        {
            if (ob is DirectorModel)
            {
                _person = new DirectorModel();
            }

            if (ob is ManagerModel)
            {
                _person = new ManagerModel();                
            }
        }
        public void GetAllData()
        {
            _person.SetPersonalData();
            Console.WriteLine("I can live:{0}", _person.CalculateAgeForLife(_person._personAge));
            _person.GetAge();
            _person.GetPersonData();
        }

    }
}