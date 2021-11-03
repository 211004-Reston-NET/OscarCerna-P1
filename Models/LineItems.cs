

namespace Models
{
    public class LineItems
    {
        private Product product;
        private int quantity;

        public Product Product { get{return product;} set {product = value;} }
        public int Quantity { get {return quantity;} set {quantity = value;} }

        public int LineItemID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int StoreID { get; set; }

        public override string ToString()
        {
            return $"ProductID: {ProductID}\n OrderID: {OrderID}\nQuantity: {Quantity}";
        }
    }
}