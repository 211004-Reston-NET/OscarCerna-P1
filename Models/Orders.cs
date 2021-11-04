using System;
using System.Collections.Generic;

namespace Models
{
    public class Orders
    {  
        public Orders()
        {
            LineItems = new HashSet<LineItem>();
        }
        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual StoreFront Store { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }

        public override string ToString()
        {
            return $"OrderID: {OrderId}\n CustomerID: \nStoreID: {StoreId}\nOrderDate: {0:dd/MM/yyyy}\nTotalPrice: {TotalPrice}";
        }
    }
}