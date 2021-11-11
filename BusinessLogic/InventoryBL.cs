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
        public List<Inventory> GetInventoryByStoreId(int p_Id)
        {
           return _repo.GetInventoryByStoreId(p_Id);
        } 
    } 
}