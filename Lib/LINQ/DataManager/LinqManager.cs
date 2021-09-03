using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lib.Models.Persons;

namespace Lib.LINQ.DataManager
{
    public class LinqManager
    {
        private static readonly ArrayList _collectionToShow = new();

        #region Showing Results
            public void ReturnGeneralCollection()
            {
                foreach (var element in _collectionToShow) ShowResult(element);
            }

            private static void ShowResult(Object obj)
            {
                Console.WriteLine("\t==Result:==");
                switch (obj)
                {
                    case List<string> list:
                        list.ForEach(Console.WriteLine);
                        break;
                    case List<User> listUser:
                        listUser.ForEach(usr => Console.WriteLine($"Name: {usr.Name} ID: {usr.Id}"));
                        break;
                    case Dictionary<string, User> dictUser:
                        dictUser.Values.ToList().ForEach(usr => Console.WriteLine($"Name: {usr.Name} ID: {usr.Id}"));
                        break;
                    case User user:
                        Console.WriteLine($"Name: {user.Name}, Age:{user.Age}, Salary: {user.Salary} ID: {user.Id}");
                        break;
                }
            }
            public static void AddToGeneralCollection(object objectToAdd)
            {
                _collectionToShow?.Add(objectToAdd);
            }
        #endregion

        #region LINQ Queries
        
            public static void LinqSelect()
            {
                Console.WriteLine("\t==Linq Select all users==");
                
                var list = ListManager.ReturningGeneratedUsersList();
                var result = list.Select(c => c).ToList();
                result.ForEach(ShowResult);
            }

            public static void LinqSelectByParameter()
            {
                Console.WriteLine("\n\t==Linq Select By Parameter==\nList of the Users:");
                
                List<User> users = new();
                users.AddRange(ListManager.ReturningGeneratedUsersList());
                users.Add(new User("Ivan", "Surname", 20, 20.3d, Guid.NewGuid()));
                users.ForEach(ShowResult);
                
                    var result = users.Where(c => c.Name.Equals("Ivan")).ToList();
                    Console.WriteLine("=Selected User=");
                    result.ForEach(ShowResult);
            }

            public static void LinqTakeWhile()
            {
                Console.WriteLine("\n\t==Linq Take While==");
                
                List<User> users = new();
                users.AddRange(ListManager.ReturningGeneratedUsersList());
                users.ForEach(ShowResult);
                Console.WriteLine("\n\t**Users between 18 and 50");
                    var result = users.TakeWhile(c=>c.Age<90).ToList();
                    if(result.Count==0) Console.WriteLine($"Function Take while close work because first user has age: {users.First().Age}");
                    result.ForEach(ShowResult);
            }

            public static void LinqSelectSortedByAgeDesc()
            {
                Console.WriteLine("\n\t==Linq Sort by age desc==");
                
                List<User> users = new();
                users.AddRange(ListManager.ReturningGeneratedUsersList());
                users.ForEach(ShowResult);
                Console.WriteLine("\n\t **Sort by Age desc");
                var result = users.OrderByDescending(user => user.Age).ToList();
                result.ForEach(ShowResult);
            }
            
            public static void LinqSelectLastOrDefault()
            {
                Console.WriteLine("\n\t==Linq Last Or default==");
                
                List<User> users = new();
                users.AddRange(ListManager.ReturningGeneratedUsersList());
                users.ForEach(ShowResult);
                Console.WriteLine("\n\t **Last:");
                ShowResult(users.ToHashSet().LastOrDefault());
            }
            
        #endregion
    }
}