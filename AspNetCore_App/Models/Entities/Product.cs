﻿namespace AspNetCore_App.Models.Entities
{
	public class Product
	{
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public short? UnitsInStock { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? CategoryId { get; set; }

	}
}
