using System;
using System.Collections.Generic;
using Lib.Models.Persons;

namespace Lib.LINQ.DataManager
{
    public class ListManager
    {
        private static List<string> _strList = new();
        private static readonly List<User> _usersList = new();

        
        public static List<User> ReturningGeneratedUsersList()
        {
            var list = new List<User>()
            {
                new User().CreateNewRandomUser(),
                new User().CreateNewRandomUser(),
                new User().CreateNewRandomUser()
            };
            return list;
        }
        
        public List<string> ReturnGeneratedStringsList()
        {
            var list = new List<string>()
            {
                "str1", "str2", "str3", "str4"
            };
            
            return list;
        }
        
        public List<User> AddItemToUsersList(User user)
        {
            _usersList.Add(user);
            return _usersList;     
        }
        public List<string> SetStringListByList(List<string> innerList)
        {
            _strList = innerList ?? throw new ArgumentNullException();
            return _strList;     
        }
        public List<string> SetStringListByArray(IEnumerable<string> stringsArray)
        {
            try
            {
                _strList.AddRange(stringsArray);
                return _strList;
            }
            catch { throw new ArgumentNullException(); }
        }
    }
}