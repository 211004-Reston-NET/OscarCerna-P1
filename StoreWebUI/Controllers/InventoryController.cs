using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Controllers
{
    public class InventoryController : Controller
    {
        private readonly InventoryBL _invBL;
        private readonly ProductBL _prodBL;
        private readonly StoreBL _storeBL;
        public InventoryController(InventoryBL p_invBL, ProductBL p_prodBL, StoreBL p_storeBL)
        {
            this._invBL = p_invBL;
            this._prodBL = p_prodBL;
            this._storeBL = p_storeBL;
        }
        // GET: InventoryController
        public ActionResult Index()
        {
            return View(_invBL.GetAllInventory()
                   .Select(inv => new InventoryVM(inv))
                    .ToList());
        }

        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int p_id)
        {

            return View(new InventoryVM(_invBL.GetInventoryByProductId(p_id)));
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(InventoryVM p_inv)
        {
            Inventory i = _invBL.GetInventoryById(p_inv.InventoryId);
            i.Quantity += p_inv.Quantity;
            _invBL.UpdateInventory(i);
            return RedirectToAction(nameof(Index));
        }

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
