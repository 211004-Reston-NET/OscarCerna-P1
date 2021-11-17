

namespace Models
{
    public class LineItem
    {
        public int LineItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        //public decimal price { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }

        public override string ToString()
        {
            return $"ProductID: {ProductId}\n OrderID: {OrderId}\nQuantity: {Quantity}";
        }
    }
}