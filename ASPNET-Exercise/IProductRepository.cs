using System;
using System.Collections.Generic;
using ASPNET_Exercise.Models;

namespace ASPNET_Exercise
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetAllProducts();
		public Product GetProduct(int id);
		public void UpdateProduct(Product product);
		public void InsertProduct(Product newProduct);
		public IEnumerable<Category> GetCategories();
		public Product AssignCategory();
		public void DeleteProduct(Product product);
	}
}

