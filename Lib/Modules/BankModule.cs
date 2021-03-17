using System;
using System.Reflection.Emit;
using System.Collections.Generic;
using Lib.Models.Companies;
using Lib.Models.Persons;

namespace Lib.Modules
{
    public class BankModule
    {
        public Bank Bank { get; }
        public PrivatBank PrivatBank { get; }

        public BankModule(Bank bank, PrivatBank privatBank)
        {
            Bank = bank;
            PrivatBank = privatBank;
        }

        public void GetAllUsersFromBank(List<Customer> customers)
        {
            foreach(Customer customer in customers)
            {
                Console.WriteLine($"\ncustomer {customer.CustomerName +"\n" + customer.CustomerAge +"\n" + customer.CustomerSurname}");
            }
        }
        
    }
}