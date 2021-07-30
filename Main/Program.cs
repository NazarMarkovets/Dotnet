using System;
using System.Linq;
using Lib.AbstractClassUsage;
using Lib.Models.Companies;
using Lib.Models.Persons;
using Lib.Modules;

namespace Main
{
    internal static class Program
    {

        public static void Main()
        {
            UsingPersonInterface();
            UsingBankModule();
            UsingDictionary();
            UsingAbstractClass();
        }


        /// <summary>
        /// <remarks>
        /// Create person module class to do implementation of IPerson.
        /// Initialize param must get new object, otherwise it returns exception
        /// </remarks>
        /// </summary>
        private static void UsingPersonInterface()
        {
            var person = new PersonModule();
            person.InitializePerson(new ManagerModel("Daniel", 55));
            person.GetAllData();
            person.InitializePerson(new WorkerModel("Gloria", 22));
            person.GetAllData();
        }

        private static void UsingBankModule()
        {
            var bankModule = new BankModule(
                    new Bank("Global Bank", 2000),
                    new PrivatBank("Privat24", 5, 50)
                    );
            bankModule.Bank.GetBankData();
            bankModule.PrivatBank.GetBankData();
            bankModule.GetAllUsersFromBank(bankModule.Bank.ReturnAllUsers());
            bankModule.GetAllUsersFromBank(bankModule.PrivatBank.ReturnAllUsers());

        }

        private static void UsingDictionary()
        {
            var dictionaryModule = new DictionaryModule();
            dictionaryModule.AddDataToDictionary(dictionaryModule.someDictionary);
            dictionaryModule.GetAllDictionaryKeys(dictionaryModule.someDictionary);
            dictionaryModule.GetDataFromDictionary(dictionaryModule.someDictionary);
            dictionaryModule.TrimDictionary(dictionaryModule.someDictionary, 4);
            dictionaryModule.TryGetDictionaryValue(dictionaryModule.someDictionary, "key 2");
            dictionaryModule.SearchValueByKey(dictionaryModule.someDictionary, "key 1");
            var returnedDictionaryKeys = dictionaryModule.ReturnKeys(dictionaryModule.someDictionary).ToList();
            returnedDictionaryKeys.ForEach(key=>Console.Write($"Returned Keys: {key} \n"));
            Console.WriteLine();
        }

        /// <summary>
        /// <remarks>
        /// Showing Upcast Features for Abstract class Person
        /// </remarks>
        /// </summary>
        private static void UsingAbstractClass()
        {
            Person person = new Employer("C1", 300.50m);
            person.Age = 50;
            person.ShowAge();
            person.ShowCategory();
            person.ShowAgeNotAbstract();
            person.ShowPersonSalary();
            Console.WriteLine($"Employee percents is {person.GetPersentsOfSalary()}");
            
            //---- Worker

            person = new UsualWorker(50.50m);
            person.ShowAge();
            person.ShowAgeNotAbstract();
            person.ShowPersonSalary(50.50d);
            person.ShowPersonSalary();
            person.ShowCategory();
            Console.WriteLine($"Usual Worker persents is {person.GetPersentsOfSalary()}");

            // -- Not using UpCast
            Employer employer = new Employer("C2", 900m);
            employer.ShowAge();
            employer.ShowCatagory();
        }
    }

}