using AspNetCore_App.Areas.Uygulama.Models;
using AspNetCore_App.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_App.Areas.Uygulama.Controllers
{
	[Area("Uygulama")]
    public class HomeController : Controller
	{
		NorthwindDbContext _dbContext;
        public HomeController(NorthwindDbContext dbContext)
        {
			_dbContext = dbContext;// parametre ile gelen dbContext instance program.cs içerisinde addDbContext metodu ile gelir...
		}

		public IActionResult Index()
		{
			// Take metodu sql dilindeki top ifadesidir...

			// iki adet model var...
			// bu modellerden view'a sadece 1 tanesi gönderilebilir...bu yüzden view'a özel bir model tanımı yapıyoruz.. Adına ProductIndexViewModel

			var products = _dbContext.Products.Take(6).ToList();

			var stokAzalan = _dbContext.Products.Where(c => c.UnitsInStock > 0 && c.UnitsInStock < 10).Take(6).ToList();

			HomeIndexViewModel vm = new HomeIndexViewModel();
			vm.Vitrins = products;
			vm.EnCokSatans = stokAzalan;

			return View(vm);
		}

	}
}
