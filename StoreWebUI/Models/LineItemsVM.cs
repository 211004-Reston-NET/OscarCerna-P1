using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class LineItemsVM
    {
        public LineItemsVM(LineItem _item)
        {
            this.LineItemId = _item.LineItemId;
            this.OrderId = _item.OrderId;
            this.ProductId = _item.ProductId;
            this.Quantity = _item.Quantity;
        }

        public int LineItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
