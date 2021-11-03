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
        public List<Inventory> GetInventory(int p_store)
        {
            List<Inventory> listOfInventory = _repo.GetInventory(p_store);
            return listOfInventory;
        } 
    } 
}