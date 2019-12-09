using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileError.Model.Model;
using CompileError.Manager.Manager;

namespace CompileError.Console
{
    class Program
    {
        private static readonly ProductManager _productManager = new ProductManager();
        private static readonly CategoryManager _categoryManager = new CategoryManager();
        static void Main(string[] args)
        {
            Category category = new Category()
            {
                Code = "PC-3",
                Name = "PC",
                Products = new List<Product>()
                {
                    new Product()
                    {
                        Name = "Apple",
                        ReorderLevel = 20
                    }
                }
            };
            _categoryManager.Add(category);
            

            Product product = new Product()
            {
                Code = "m-1002",
                Name = "Samsung Galaxy Y",
                CategoryId = 1,
                ReorderLevel = 100,
                Description = "First Generation Galaxy Phone"
            };

            _productManager.Add(product);

            //CustomerManager _customerManager = new CustomerManager();
            //  Customer customer = new Customer()
            //  {
            //      Code = "c002",
            //      Name="nandita",
            //      Address="airport",
            //      Email="nandita@gmail.com",
            //      Contact="01700000000",
            //      LoyalityPoint=20


            //  };

            /*     if(_customerManager.Add(customer))
                 {
                     System.Console.WriteLine("Added");
                 }
                 else
                 {
                     System.Console.WriteLine("can not added");
                 }*/

            /*   if (_customerManager.Delete(2))
               {
                   System.Console.WriteLine("deleted");
               }
               else
               {
                   System.Console.WriteLine("can not delete");
               }
               */
            //customer.Id = 1;
            //customer.Code = "111";
            //customer.Name = "Nandita Mandal";
            //customer.Email = "nandita@gmail.com";
            //customer.Contact = "0190000";
            //customer.LoyalityPoint = 20;

            //    if (_customerManager.Update(customer))
            //  {
            //    System.Console.WriteLine("updated..");
            //}
            //else
            //{
            //  System.Console.WriteLine("can not updated...");
            ///}
            //var Customers = _customerManager.GetAll();
            //foreach(var cus in Customers)
            //{
            //    System.Console.WriteLine("code: " + cus.Code+" "+
            //        "name: " + cus.Name+" "+"Address "+ cus.Address+" "+"Contact "
            //        +cus.Contact+" "+"Loyality Point "+cus.LoyalityPoint
            //        );
            //}

            //var acustomers = _customerManager.Search(1);

            //System.Console.WriteLine("Code: "+acustomers.Code+"\n"
            //    +"Name "+acustomers.Name+"\n "+"Address "+acustomers.Address+"\n "
            //    +"Contact "+acustomers.Contact+ "\n "+"Loyality point "+acustomers.LoyalityPoint
            //    );


            System.Console.ReadKey();


            


        }
    }
}
