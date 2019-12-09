using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompileError.Model.Model;
using CompileError.Manager.Manager;

namespace CompileError.Category
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryManager _categoryManager = new CategoryManager();
            Model.Model.Category category = new Model.Model.Category()
            {
                Code = "0003",
                Name = "Laptop"
            };

            //Add
            if (_categoryManager.Add(category))
            {
                Console.WriteLine("Saved");
            }
            else
            {
                Console.WriteLine("Not Saved");
            }

            //Delete
            if (_categoryManager.Delete(1))
            {
                Console.WriteLine("Deleted");
            }
            else
            {
                Console.WriteLine("Not Deleted");
            }

            //Update
            category.Id = 1;
            category.Code = "0001";
            category.Name = "Desktop";
            if (_categoryManager.Update(category))
            {
                Console.WriteLine("Updated");
            }
            else
            {
                Console.WriteLine("Not Updated");
            }

            var Categories = _categoryManager.ShowAll();
            var Category = _categoryManager.Search(2);

            foreach(var cate in Categories)
            {
                Console.WriteLine("Code: " + cate.Code + " Name: " + cate.Name);
            }

            Console.WriteLine("Code: " + Category.Code + " Name: " + Category.Name);
            Console.ReadKey();
        }
    }
}
