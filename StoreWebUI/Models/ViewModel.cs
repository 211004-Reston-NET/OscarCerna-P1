using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class ViewModel
    {

        public List<Customer> Customers { get; set; }
        public List<StoreFront> Stores { get; set; }

    }
}
