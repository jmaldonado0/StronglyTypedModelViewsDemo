using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StronglyTypedModelViewsDemo.Models;

namespace StronglyTypedModelViewsDemo.Controllers
{
    public class ProductsController : Controller
    {
        static List<Product> _Products = new List<Product>
        {
            new Product
            {
                ProductID = 1,
                ProductName = "AMD Ryzen 3990",
                Quantity = 100,
                UnitInStock = 50,
                Discontinued = false,
                Cost = 3000,
                LaunchDate = new DateTime(2021,10,1)
            },
            new Product
            {
                 ProductID = 2,
                ProductName = "AMD Ryzen 3970",
                Quantity = 100,
                UnitInStock = 70,
                Discontinued = false,
                Cost = 2500,
                LaunchDate = new DateTime(2021,10,5)
            },
            new Product
            {
                 ProductID =3,
                ProductName = "AMD Ryzen 3960",
                Quantity = 100,
                UnitInStock = 80,
                Discontinued = false,
                Cost = 2000,
                LaunchDate = new DateTime(29,10,15)
            },

            new Product
            {
                 ProductID = 4,
                ProductName = "AMD Ryzen 3950",
                Quantity = 100,
                UnitInStock = 40,
                Discontinued = false,
                Cost = 1500,
                LaunchDate = new DateTime(2021,10,25)
            }
        };
         public IActionResult Index()
        {


            return View(_Products);
        }

        public IActionResult Details(int id)
        {
            var prod = _Products.Find(prod => prod.ProductID.Equals(id));
            return View(prod);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prod = _Products.Find(prod => prod.ProductID.Equals(id));
            return View(prod);
        }

        [HttpPost]
        public IActionResult Edit(Product modifiedproduct)
        {
            var prod = _Products.FirstOrDefault( prod => prod.ProductID.Equals(modifiedproduct.ProductID));
            var indexOf = _Products.IndexOf(prod);
            modifiedproduct.Tax = modifiedproduct.Cost * 10 / 100;

            _Products[indexOf] = modifiedproduct;

          return View("Index", _Products);

            
            //return View(modifiedproduct);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prod = _Products.Find(prod => prod.ProductID.Equals(id));
            return View(prod);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteProduct(int id)
        {
            var prod = _Products.Find(prod => prod.ProductID.Equals(id));
            _Products.Remove(prod);
            return View("Index", _Products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product NewProduct)
        {
            if(ModelState.IsValid)
            {
                NewProduct.Tax = NewProduct.Cost * 10 / 100;
                _Products.Add(NewProduct);
                return View("Index", _Products);
            }
            else
            {
                return View();
            }
        }

    }
}
