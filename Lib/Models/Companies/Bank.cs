using System;

namespace Lib.Models.Companies
{
    public class Bank
    {
        protected int CountOfUsers { get; set; }
        protected string BankName { get; set; }
        protected TimeSpan OpenTime, CloseTime;

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


    }
}