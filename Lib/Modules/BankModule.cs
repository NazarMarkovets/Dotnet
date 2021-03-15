using Lib.Models.Companies;

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

        
    }
}