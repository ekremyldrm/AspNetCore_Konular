using AspNetCore_App.Models;
using AspNetCore_App.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_App.Controllers
{
	public class UrunController : Controller
	{
		NorthwindDbContext _dbContext;
		public UrunController(NorthwindDbContext dbContext)
		{
			_dbContext = dbContext;// parametre ile gelen dbContext instance program.cs içerisinde addDbContext metodu ile gelir...
		}
		public IActionResult Index()
		{
			// Take metodu sql dilindeki top ifadesidir...


			// iki adet model var...
			// bu modellerden view'a sadece 1 tanesi gönderilebilir...bu yüzden view'a özel bir model tanımı yapıyoruz.. Adına ProductIndexViewModel

			var products = _dbContext.Products.Take(10).ToList();

			var stokAzalan = _dbContext.Products.Where(c => c.UnitsInStock > 0 && c.UnitsInStock < 10).Take(10).ToList();

			ProductIndexViewModel vm = new ProductIndexViewModel();
			vm.Vitrins = products;
			vm.EnCokSatans = stokAzalan;

			return View(vm);
		}

		public IActionResult Detail(int id)
		{
			var product = _dbContext.Products.FirstOrDefault(c => c.ProductId == id);

			return View(product);
		}
	}
}
