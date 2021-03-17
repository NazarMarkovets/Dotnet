using System;
using System.Collections.Generic;
using System.Linq;
using Lib.Models.Persons;

namespace Lib.Models.Companies
{
    public class PrivatBank:Bank
    {
        private int CountOfDepartments { get; }
        public PrivatBank(string name, int countOfUsers, int countOfDepartments) : base(name, countOfUsers)
        {
            CountOfDepartments = countOfDepartments;
            OpenTime = new TimeSpan(9, 30, 0);
        }

        public override void GetBankData()
        {
            Console.WriteLine($"\n\tData from Privat class: {BankName}, Users: {CountOfUsers}, Opens: {OpenTime}, Closes: {CloseTime}, Deps: {CountOfDepartments}");
        }

        public override List<Customer> ReturnAllUsers()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(){CustomerName = "Petr", CustomerAge = 15, CustomerSurname = "Michno"});
            customers.Add(new Customer(){CustomerName = "Anna", CustomerAge = 18, CustomerSurname = "Michno"});
            customers.Add(new Customer(){CustomerName = "Maria", CustomerAge = 25, CustomerSurname = "Michno"});
            customers.Add(new Customer(){CustomerName = "Ivan", CustomerAge = 45, CustomerSurname = "Ivanov"});
            
             var data = from item in customers
                        where item.CustomerAge >=18
                        select item;
            List<Customer> sorted = new List<Customer>();
            sorted.AddRange(data);
            return sorted;
        }
    }
}   