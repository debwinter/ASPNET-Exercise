﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNET_Exercise.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNET_Exercise.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repo;

        public ProductController(IProductRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var products = repo.GetAllProducts();
            return View(products);
        }

        public IActionResult ViewProduct(int id)
        {
            var prod = repo.GetProduct(id);
            return View(prod);
        }

        public IActionResult UpdateProduct(int id)
        {
            var prod = repo.GetProduct(id);
            if (prod == null) return View("ProductNotFound");
            return View(prod);
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            repo.UpdateProduct(product);
            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }

        public IActionResult InsertProduct(Product newProduct)
        {
            var prod = repo.AssignCategory();
            return View(prod);
        }

        public IActionResult InsertProductToDatabase(Product newProduct)
        {
            repo.InsertProduct(newProduct);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProductFromDatabase(Product product)
        {
            repo.DeleteProduct(product);
            return RedirectToAction("Index");
        }
    }
}

