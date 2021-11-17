using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class CartVM
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
