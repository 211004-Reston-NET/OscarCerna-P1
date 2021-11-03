using System;
using System.Collections.Generic;

namespace Models
{
    public class Orders
    {
        private List<LineItems> lineItems = new List<LineItems>();
        private int storeid;
        private decimal totalPrice;
        public List<LineItems> LineItems { get{return lineItems;} set {lineItems = value;} }

        public int OrderID { get; set; }
        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get{return totalPrice;} set {totalPrice = value;} }
        
        public override string ToString()
        {
            return $"OrderID: {OrderID}\n CustomerID: \nStoreID: {StoreID}\nOrderDate: {0:dd/MM/yyyy}\nTotalPrice: {TotalPrice}";
        }
    }
}