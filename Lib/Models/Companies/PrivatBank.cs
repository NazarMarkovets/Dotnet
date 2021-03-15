using System;

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
    }
}   