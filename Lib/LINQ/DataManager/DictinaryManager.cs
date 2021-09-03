#nullable enable
using System.Collections.Generic;
using Lib.Models.Persons;

namespace Lib.LINQ.DataManager
{
    public class DictionaryManager
    {
        private Dictionary<string, User>? UsersDictionary;

        public Dictionary<string, User> FillDictionaryFromList(List<User> receivedList)
        {
            UsersDictionary = new Dictionary<string, User>();
            receivedList.ForEach(value=>UsersDictionary.Add(value.Id.ToString(), value));

            return UsersDictionary;
        }
    }
}