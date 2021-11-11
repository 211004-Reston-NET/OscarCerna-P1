using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Models
{
    public class StoreVM
    {
        public StoreVM(StoreFront p_store)
        {
            this.StoreId = p_store.StoreId;
            this.StoreName = p_store.StoreName;
            this.StoreAddress = p_store.StoreAddress;
        }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }

    }
}
