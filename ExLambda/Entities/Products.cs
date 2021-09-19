using System;
using System.Collections.Generic;
using System.Text;

namespace ExLambda.Entities
{
	class Products
	{
		public Products(string name, double price)
		{
			Name = name;
			Price = price;
		}

		public string Name{ get; set; }
		public double Price { get; set; }
	}
	
}
