using BusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebUI.Controllers
{
    public class LineItemController : Controller
    {
        private readonly LineItemBL _itemBL;
        private readonly ProductBL _prodBL;
        private readonly OrderBL _orderBL;

        public LineItemController(LineItemBL p_itemBL, ProductBL p_prodBL, OrderBL p_orderBL)
        {
            this._itemBL = p_itemBL;
            this._prodBL = p_prodBL;
            this._orderBL = p_orderBL;
        }
        // GET: LineItemController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LineItemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LineItemController/Create
        public ActionResult Create()
        {
            var orders = _orderBL.GetAllOrders();
            var products = _prodBL.GetAllProduct();

            ViewData["order"] = orders;
            ViewData["product"] = products;
            return View();
        }

        // POST: LineItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LineItem _item)
        {
            if (ModelState.IsValid)
            {
                _itemBL.AddLineItems(new LineItem()
                {
                    ProductId = _item.ProductId,
                    OrderId = _item.OrderId,
                    Quantity = _item.Quantity,
           
                });

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: LineItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LineItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: LineItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LineItemController/Delete/5
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
