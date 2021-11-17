using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class StoreVM
    {
        public StoreVM(StoreFront _store)
        {
            this.StoreId = _store.StoreId;
            this.Name = _store.StoreName;
            this.Address = _store.StoreAddress;
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
