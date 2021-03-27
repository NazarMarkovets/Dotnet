using System.Globalization;
using System;
using Lib.Models.Companies;
using Lib.Models.Persons;
using Lib.Modules;

namespace Main
{
    internal static class Program
    {
        
        public static void Main()
        {
            
            #region StraightClassImplementation
                // DirectorModel directorModel = new DirectorModel();
                // directorModel.SetPersonalData();
                // directorModel.GetAge();
            #endregion

            #region UsingPersonInterface
                
            // Create person module class to do implementation of IPerson
            // Initialize param must get new object, otherwise it returns exception
            
                // var person = new PersonModule();
                // person.InitializePerson(new ManagerModel("Daniel", 55));
                // person.GetAllData();
                // person.InitializePerson(new WorkerModel("Gloria",22));
                // person.GetAllData();
            #endregion
            
            #region UsingBankModule
            /*    
                var bankModule = new BankModule(
                        new Bank("Global Bank", 2000),
                        new PrivatBank("Privat24", 5, 50)
                        );
                bankModule.Bank.GetBankData();
                bankModule.PrivatBank.GetBankData();
                bankModule.GetAllUsersFromBank(bankModule.Bank.ReturnAllUsers());
                bankModule.GetAllUsersFromBank(bankModule.PrivatBank.ReturnAllUsers());
            */
            #endregion

            #region UsingDictionary
            /*
                DictionaryModule dictionaryModule = new DictionaryModule();
                dictionaryModule.AddDataToDictionary(dictionaryModule.someDictionary);
                dictionaryModule.GetAllDictionaryKeys(dictionaryModule.someDictionary);
                dictionaryModule.GetDataFromDictionary(dictionaryModule.someDictionary);
                dictionaryModule.TrimDictionary(someDictionary: dictionaryModule.someDictionary, 4);
                dictionaryModule.TryGetDictionaryValue(dictionaryModule.someDictionary, "key 2");
                dictionaryModule.SearchValueByKey(dictionaryModule.someDictionary, "key 1");
                var returnedDictionaryKeys = dictionaryModule.ReturnKeys(dictionary: dictionaryModule.someDictionary);
            */
            #endregion
            
            
            
        }
    }

}