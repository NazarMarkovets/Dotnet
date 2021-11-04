using System.Security.AccessControl;
using System;
using System.Reflection.Emit;
using System.Collections.Generic;
using Lib.Models.Companies;
using Lib.Models.Persons;
using static System.Console;
namespace Lib.Modules
{
    public class DictionaryModule
    {
        static string returnedValue;
        public Dictionary<string, string> someDictionary { get; set; }
        
        public DictionaryModule()
        {
            someDictionary = new Dictionary<string, string>();
        }
        

        public void AddDataToDictionary(Dictionary<string, string> someDictionary)
        {
            WriteLine("\n\tMethod: AddDataToDictionary");
            someDictionary.TryAdd("key 1", "value1");
            someDictionary.TryAdd<string,string>("key 2", "SpecialValue");
            foreach (var item in someDictionary)
            {
                WriteLine(item.Key +"  "+ item.Value);
            }
            WriteLine();
        }
        public void GetDataFromDictionary(Dictionary<string,string> someDictionary)
        {
            WriteLine("\n\tMethod: GetDataFromDictionary");
            var ienum = someDictionary.GetEnumerator();
            while(ienum.MoveNext())
            {
                var item = ienum.Current;
                WriteLine(item.Key +" "+ item.Value);
            }
        }
        public void TryGetDictionaryValue(Dictionary<string, string> someDictionary, string searchedKey)
        {
            WriteLine($"\n\tMethod TryGetDictionaryValue:");
                if (someDictionary.TryGetValue(searchedKey, out returnedValue))
                    WriteLine($"For key = \"{searchedKey}\", value = {returnedValue}.");
                else
                    WriteLine($"Key = \"{searchedKey}\" is not found.");
    
        }
        public void SearchValueByKey(Dictionary<string, string> someDictionary, string searchedKey)
        {
            WriteLine($"\n\tMethod SearchValueByKey:");
            if(someDictionary.ContainsKey(searchedKey))
            {
                WriteLine("Key was found");
                var result = someDictionary.GetValueOrDefault<string,string>(searchedKey);
                WriteLine(result);
                return;
            }
            WriteLine("Key was not found");
        }
        public string[] ReturnKeys(Dictionary<string, string> dictionary)
        {
            WriteLine($"\n\tMethod ReturnKeys returned keys:");
            string[] keys = new string[dictionary.Count];
            dictionary.Keys.CopyTo( keys,0);
            return keys;
        }
        public void GetAllDictionaryKeys(Dictionary<string, string> someDictionary)
        {
            var arrayKeys = ReturnKeys(someDictionary);
                int counter = 0;
                    WriteLine($"\n\tMethod GetAllDictionaryKeys - Method ReturnReys:\nFound Keys:");
                    foreach(var i  in arrayKeys)
                    {
                        counter++;
                        WriteLine($"{counter}: " + i);
                    }
        }

        public void TrimDictionary(Dictionary<string,string> someDictionary, int futureCapasityOfDict)
        {
            WriteLine($"\n\tMethod TrimDictionary:");
            /// Sets the future capasity for dictionary for saving storage resources
            ///if we know that new elements won't be added in the future
            if(futureCapasityOfDict < someDictionary.Count)
            {
                WriteLine($"The selected capasity of array is less than current: Entered {futureCapasityOfDict}, Current {someDictionary.Count} ");
                WriteLine("Do you want to clear data and trim? [1] - Yes, [2] - No");
                var i = int.Parse(Console.ReadLine() ?? throw new ArgumentException());
                    if(i == 2 || i<=0 || i>2)
                    {
                        System.Console.WriteLine("Procedure is terminated");
                        return;
                    } 
                someDictionary.Clear();
                someDictionary.TrimExcess(capacity: futureCapasityOfDict);
                WriteLine($"Array was cleaned to trim and trimming is finished. The capasity is {someDictionary.EnsureCapacity(futureCapasityOfDict)}");
            }
            else{
                someDictionary.TrimExcess(capacity: futureCapasityOfDict);
                WriteLine($"Array was cleaned to trim and trimming is finished. The capasity is {someDictionary.Count}");

            }
        }
    }
}