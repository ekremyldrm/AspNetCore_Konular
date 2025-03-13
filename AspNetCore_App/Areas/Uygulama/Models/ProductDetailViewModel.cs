using AspNetCore_App.Models.Entities;

namespace AspNetCore_App.Areas.Uygulama.Models
{
	// ViewModel 
	public class ProductDetailViewModel
	{
		public Product Product { get; set; }

		public Category Category { get; set; }

		public List<Product> SonGezilenler { get; set; }
	}
}
