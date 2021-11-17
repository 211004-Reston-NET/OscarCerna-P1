using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreWebUI.Helpers;
using Models;
using BusinessLogic;
using StoreWebUI.Models;

namespace StoreWebUI.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        private ProductBL _prodBL;

        public CartController(ProductBL p_prodBL)
        {
            this._prodBL = p_prodBL;
        }
        // GET: CartController

        [Route("Index")]
        public ActionResult Index1()
        {
            return View();
        }

        [Route("buy/{id}")]
        public ActionResult AddToCart(int id)
        {
            if (SessionHelper.GetObjectAsJson<List<LineItem>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<LineItem>();
                cart.Add(new LineItem() { Product = _prodBL.GetProductById(id), Quantity = 1});
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                var cart = SessionHelper.GetObjectAsJson<List<LineItem>>(HttpContext.Session, "cart");
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new LineItem() { Product = _prodBL.GetProductById(id), Quantity = 1 });
                }
                else
                {
                    cart[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Index");
        }

        private int Exists(List<LineItem> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId == id)
                {
                    return i;
                }
            }
            return -1;
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
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

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
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

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
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
