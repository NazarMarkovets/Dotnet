using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Dotnet.Lib;
using Lib.AbstractClassUsage;
using Lib.Models.Companies;
using Lib.Models.Persons;
using Lib.Modules;
using Lib.Patterns.Builder;
using TraceManager;

namespace Main
{
    internal static class Program
    {

        public static void Main()
        {
            // UsingPersonInterface();
            // UsingBankModule();
            // UsingDictionary();
            // UsingAbstractClass();
            //UsingBuilderPattern();
            //UsingDelegates();
            
            // LinqManager.LinqSelect();
            // LinqManager.LinqSelectByParameter();
            // LinqManager.LinqTakeWhile();
            // LinqManager.LinqSelectSortedByAgeDesc();
            // LinqManager.LinqSelectLastOrDefault();
            // CreatingHashMap();

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
                    new PrivatBank("Privat24", 5, 50));
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
            
            employer.ShowPersonSalary();
            employer.ShowCatagory();
        }

        private static void UsingBuilderPattern()
        {
            Director director = new Director("Part 1 ", "Part 2 ");
            
            ConcreteBuilderA concreteBuilderA = new ConcreteBuilderA();
            director.Construct(concreteBuilderA);
            Product product1 = concreteBuilderA.ReturnAllProducts();
            product1.ShowAllProducts();
            
            ConcreteBuilderB concreteBuilderB = new ConcreteBuilderB();
            director.ChangeParts("Part3 ", "Part 4");
            director.Construct(concreteBuilderB);

            Product product2 = concreteBuilderB.ReturnAllProducts();
            product2.ShowAllProducts();
        }
        
        /// <summary>
        /// Shows working of delegates
        /// Show 10 random calls of 4 types of methods
        /// Use Tracing in TraceManager
        /// </summary>
        private static void UsingDelegates()
        {
            var counter = 0;
            var random = new Random();
            var tracing = new Tracing();
            while (counter < 10)
            {
                var value = random.Next(1, 10);
                object Result = null;
                switch (value % 2)
                {
                    case 0 when value < 5:
                    {
                        DelegatesExample.CreateUserWithPredefinedData userWithPredefinedData = DelegatesExample.CreateWorkerModel_Stat;
                        tracing.AddToTracing(counter, userWithPredefinedData);
                        Result = userWithPredefinedData.Invoke();
                        tracing.ShowInfo(userWithPredefinedData);
                        tracing.GetObjectType(userWithPredefinedData);
                        break;
                    }
                    case 0 when value > 5:
                    {
                        DelegatesExample.CreateUserWithPredefinedData userWithPredefinedData = DelegatesExample.CreateManagerModel_Stat;
                        tracing.AddToTracing(counter, userWithPredefinedData);
                        Result = userWithPredefinedData();
                        break;
                    }
                    case 1 when value < 5:
                    {
                        DelegatesExample.CreateUserWithSpecialData userWithSpecialData = DelegatesExample.CreateManagerModelWithParams_Stat;
                        tracing.AddToTracing(counter, userWithSpecialData);
                        Result = userWithSpecialData("Given Manager Name", 1);
                        break;
                    }
                    default:
                    {
                        DelegatesExample.CreateUserWithSpecialData userWithSpecialData = DelegatesExample.CreateWorkerModelWithParams_Stat;
                        tracing.AddToTracing(counter, userWithSpecialData);
                        Result = userWithSpecialData("Given Worker Name", 13);
                        break;
                    }
                }
                switch (Result)
                {
                    case ManagerModel managerModel:
                        Console.WriteLine("Manager Name: " + managerModel._personName + "Manager Age: " + managerModel._personAge);
                        break;
                    case WorkerModel workerModel:
                        Console.WriteLine("Manager Name: " + workerModel._personName + "Manager Age: " + workerModel._personAge);
                        break;
                } 
                counter++;
                Console.WriteLine("===================================");
            }
            
            tracing.Notify += Tracing.Display;
            // tracing.TraceON += Tracing.OnTraceOn;
            tracing.TraceON -= Tracing.OnTraceOn;
            // trace.ForEach(Console.WriteLine);
        }

        private static void CreatingHashMap()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            
            
            var hashtable = new Hashtable { { "string", 100 } };
            var res = hashtable.Keys.Cast<List<string>>();
            Console.WriteLine(res.Select(c=>c));
            Console.WriteLine(hashtable["string"]);

            HashSet<string> set = new();
            set.Add("st1");
            string actualValue = string.Empty;
            
            set.TryGetValue("st1", out actualValue);
            Console.WriteLine(actualValue);
        }

        
    }

}