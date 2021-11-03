using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Models
{
    public class StoreFront
    {
        private string name;
        private string address;
        private List<Product> product;
        private List<Orders> orders;
        public int StoreID { get; set; }
        public string Name { get{return name;} set {name = value;} }

        public string Address       
        {
            get { return address; }
            set 
            {
                if (!Regex.IsMatch(value, @"\b\d{5}(?:-\d{4})?\b")) //returns store based on zip code 
                {
                    throw new Exception("Invaild Address Format!");
                }
                address = value;
            }
        } 
        public List<Product> Products { get{return product;} set {product = value;} }

        public List<Orders> Orders { get{return orders;} set {orders = value;} }
    
        public override string ToString()
        {
            return $"StoreID: {StoreID}\n Name: {Name}\nAddress: {Address}";
        }
    }
}