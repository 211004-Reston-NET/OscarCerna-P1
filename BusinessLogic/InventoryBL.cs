using System;
using System.Collections.Generic;
using DataAccess;
using Models;

namespace BusinessLogic
{
    public class InventoryBL
    {
        private IRepository _repo;
        
        public InventoryBL(IRepository p_repo) 
        {
         this._repo = p_repo;
        }

        public List<Inventory> GetAllInventory()
        {
                List<Inventory> listOfInventory = _repo.GetAllInventory();
                return listOfInventory;
        }

        public List<Inventory> GetInventoryByStoreId(int p_Id)
        {
           return _repo.GetInventoryByStoreId(p_Id);
        }

        public Inventory GetInventoryByProductId(int p_id)
        {
            Inventory invFound = _repo.GetInventoryByProductId(p_id);

            if (invFound == null)
            {
                throw new Exception("Item not found");
            }
            return invFound;
        }

        public Inventory GetInventoryById(int p_id)
        {
            Inventory invFound = _repo.GetInventoryById(p_id);

            if (invFound == null)
            {
                throw new Exception("Item not found");
            }
            return invFound;
        }

        public Inventory UpdateInventory(Inventory p_inv)
        {
            return _repo.UpdateInventory(p_inv);
        }
    } 
}