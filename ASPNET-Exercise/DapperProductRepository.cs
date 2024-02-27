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

        public IEnumerable<Product> GetAllProducts()
        {
            return _conn.Query<Product>("SELECT * FROM Products");
        }

        public Product GetProduct(int id)
        {
            return _conn.QuerySingle<Product>("SELECT * FROM Products WHERE ProductID = @pID", new { pID = id });
        }

        public void UpdateProduct(Product product)
        {
            _conn.Execute("UPDATE products SET Name = @newName, Price = @newPrice WHERE ProductID = @id", new { newName = product.Name, newPrice = product.Price, id = product.ProductID });
        }
    }
}

