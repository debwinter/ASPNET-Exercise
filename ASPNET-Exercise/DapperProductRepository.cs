using System;
using System.Data;
using Dapper;
using ASPNET_Exercise.Models;

namespace ASPNET_Exercise
{
	public class DapperProductRepository : IProductRepository
	{
		private readonly IDbConnection _conn;

		public DapperProductRepository(IDbConnection conn)
		{
			_conn = conn;
		}

        public Product AssignCategory()
        {
            var categoryList = GetCategories();
            var product = new Product();
            product.Categories = categoryList;
            return product;
        }

        public void DeleteProduct(Product product)
        {
            _conn.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
            _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;", new { id = product.ProductID });
            _conn.Execute("DELETE FROM Reviews WHERE ProductID = @id;", new { id = product.ProductID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM Products;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM Categories;");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM Products WHERE ProductID = @pID;", new { pID = id });
        }

        public void InsertProduct(Product newProduct)
        {
            _conn.Execute("INSERT INTO products (Name, Price, CategoryID, OnSale) VALUES (@name, @price, @catID, @onSale);", new { name = newProduct.Name, price = newProduct.Price, catID = newProduct.CategoryID, onSale = newProduct.OnSale });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @newName, Price = @newPrice, OnSale = @onSale WHERE ProductID = @id;", new { newName = product.Name, newPrice = product.Price, onSale = product.OnSale, id = product.ProductID });
        }
    }
}

