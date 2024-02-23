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
    }
}

