using System;
using System.Collections.Generic;
using Lib.Models.Persons;

namespace Lib.Models.Companies
{
    public class Bank
    {
        protected int CountOfUsers { get; set; }
        protected string BankName { get; set; }
        protected TimeSpan OpenTime, CloseTime;
        public List<Customer> customers;

        public Bank(string name, int countOfUsers)
        {
            BankName = name;
            CountOfUsers = countOfUsers;
            OpenTime = new TimeSpan(8, 0, 0);
            CloseTime = new TimeSpan(22, 0, 0);
        }

        public virtual void GetBankData()
        {
            Console.WriteLine($"\n\tData form Bank class: {BankName}, Opens: {OpenTime}, Closes: {CloseTime}, Users: {CountOfUsers}");
        }

        public virtual List<Customer> ReturnAllUsers()
        {
            customers = new List<Customer>();
            customers.Add(new Customer(){CustomerName = "Petr", CustomerAge = 15, CustomerSurname = "Michno"});
            customers.Add(new Customer(){CustomerName = "Anna", CustomerAge = 18, CustomerSurname = "Michno"});
            customers.Add(new Customer(){CustomerName = "Maria", CustomerAge = 25, CustomerSurname = "Michno"});
            customers.Add(new Customer(){CustomerName = "Ivan", CustomerAge = 45, CustomerSurname = "Ivanov"});
            
            return customers;
            
        }


    }
}