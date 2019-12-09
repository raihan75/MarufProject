using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CompileError.Models;
using CompileError.Model.Model;
using AutoMapper;
using CompilerError.Models;

namespace CompileError
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductModelView, Product>();
                cfg.CreateMap<Product, ProductModelView>();
                cfg.CreateMap<Supplier, SupplierViewModel>();
                cfg.CreateMap<SupplierViewModel, Supplier>();
                cfg.CreateMap<Purchase, PurchaseModelView>();
                cfg.CreateMap<PurchasedProduct, PurchaseModelView>();
                cfg.CreateMap<PurchaseModelView, Purchase>();
                cfg.CreateMap<PurchaseModelView, PurchasedProduct>();
                cfg.CreateMap<PurchasedProduct, PurchasedProduct>();
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.CreateMap<Customer, CategoryViewModel>();
                cfg.CreateMap<CustomerViewModel, Customer>();
            });
        }
    }
}
