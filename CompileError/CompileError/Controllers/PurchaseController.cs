using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompileError.Manager.Manager;
using CompileError.Model.Model;
using CompileError.Models;
using AutoMapper;

namespace CompileError.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly CategoryManager _categoryManager = new CategoryManager();
        private readonly ProductManager _productManager = new ProductManager();
        private readonly SupplierManager _supplierManager = new SupplierManager();
        private readonly PurchaseManager _purchaseManager = new PurchaseManager();
        private readonly PurchasedProductManager _purchasedProductManager = new PurchasedProductManager();

        [HttpGet]
        public ActionResult Add()
        {
            PurchaseModelView purchaseModelView = new PurchaseModelView();
            FillComboBox(purchaseModelView);

            return View(purchaseModelView);
        }

        [HttpPost]
        public ActionResult Add(PurchaseModelView purchaseModelView)
        {
            FillComboBox(purchaseModelView);
            return View(purchaseModelView);
        }

        private void FillComboBox(PurchaseModelView purchaseModelView)
        {
            purchaseModelView.CategorySelectListItems = _categoryManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            purchaseModelView.SupplierSelectListItems = _supplierManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            purchaseModelView.ProductSelectListItems = new List<SelectListItem>();
        }

        public JsonResult GetProductJsonResult(int categoryId)
        {
            List<Product> products = _productManager.GetAll()
                .Where(c => c.CategoryId == categoryId).ToList();

            var productIdValue = products.Select(c => new {c.Id, c.Name});

            return Json(productIdValue, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductInfoJsonResult(int productId)
        {
            PurchaseModelView purchaseModelView = new PurchaseModelView
            {
                ProductCode = _productManager.GetById(productId).Code
            };

            purchaseModelView.PurchasedProducts = _purchasedProductManager.GetAll()
                .Where(c => c.ProductId == productId).ToList();

            if (purchaseModelView.PurchasedProducts.Count!=0)
            {
                var lId = 0;
                foreach (var purchasedProduct in purchaseModelView.PurchasedProducts)
                {
                    if (purchasedProduct.Id > lId)
                    {
                        purchaseModelView.PreviousMrp = purchasedProduct.Mrp;
                        purchaseModelView.PreviousUnitPrice = purchasedProduct.UnitPrice;
                    }
                }
            }

            return Json(purchaseModelView);
        }

        public ActionResult AddToPurchaseCart(PurchaseModelView purchaseModelView)
        {
            purchaseModelView.ProductSelectListItems = _productManager.GetAll()
                .Where(c=>c.CategoryId==purchaseModelView.CategoryId).Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            PurchasedProduct purchasedProduct = Mapper.Map<PurchasedProduct>(purchaseModelView);


            purchaseModelView.PurchasedProducts.Add(purchasedProduct);



            return PartialView("Purchase/_InCartProducts", purchaseModelView);
        }

        public string TestF()
        {
            return "abc";
        }

    }
}