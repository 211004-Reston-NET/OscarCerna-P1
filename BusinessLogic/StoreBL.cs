using System;
using System.Collections.Generic;
using DataAccess;
using Models;

namespace BusinessLogic
{
    public class StoreBL
    {
        private IRepository _repo;
        public StoreBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public List<StoreFront> GetAllStores()
        {
            List<StoreFront> listOfStores = _repo.GetAllStores();
            return listOfStores;
        }
        public StoreFront GetStore(int p_id)
        {
                StoreFront storeFound = _repo.GetStore(p_id);

                if (storeFound == null)
                {
                    throw new Exception("Store was not found");
                }
            return storeFound; 
        }
    }
}