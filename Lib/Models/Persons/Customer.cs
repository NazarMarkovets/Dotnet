namespace Lib.Models.Persons
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public int CustomerAge{get;set;}
        public decimal CountOfMoneys{get;set;}

        public void GetData()
        {
            System.Console.WriteLine(CustomerAge + CustomerName + CustomerSurname);
        }
        

        
    }
}