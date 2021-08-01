using System;
using System.Collections.Generic;

namespace Lib.Patterns.Builder
{
    public class Product
    {
        private List<string> products = new();

        public void AddToList(string productName)
        {
            products.Add(productName);
        }

        public void ShowAllProducts()
        {
            products.ForEach(produc=>Console.Write(produc));
        }
    }
}