using System;
using System.Collections.Generic;
using ASPNET_Exercise.Models;

namespace ASPNET_Exercise
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetAllProducts();
	}
}

