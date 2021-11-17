using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class OrderVM
    {
        private Orders ord;

        public OrderVM()
        {

        }

        public OrderVM(Orders ord)
        {
            this.CustomerId = ord.CustomerId;
            this.StoreId = ord.StoreId;
            this.OrderDate = ord.OrderDate;
            this.TotalPrice = ord.TotalPrice;
            this.LineItems = ord.LineItems;
        }

        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int StoreId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
    }
}
