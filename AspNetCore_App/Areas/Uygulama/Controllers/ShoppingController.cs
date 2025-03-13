using AspNetCore_App.Areas.Uygulama.Models;
using AspNetCore_App.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AspNetCore_App.Areas.Uygulama.Controllers
{
	[Area("Uygulama")]
	public class ShoppingController : Controller
	{
		NorthwindDbContext _dbContext;
        public ShoppingController(NorthwindDbContext dbContext)
        {
				_dbContext = dbContext;
        }

        public IActionResult Index()
		{
            List<SepetSepetYumurta> yumartalar;
           
			string? getSepetStr = HttpContext.Session.GetString("sepet");
            if (getSepetStr != null)
                yumartalar = JsonConvert.DeserializeObject<List<SepetSepetYumurta>>(getSepetStr);
            else
                yumartalar = new List<SepetSepetYumurta>();

            return View(yumartalar);
		}

		public IActionResult Add(int ProductId)
		{

			List<SepetSepetYumurta> yumartalar;

			string? getSepetStr = HttpContext.Session.GetString("sepet");
			if (getSepetStr != null)
				yumartalar = JsonConvert.DeserializeObject<List<SepetSepetYumurta>>(getSepetStr);
			else
				yumartalar = new List<SepetSepetYumurta>();

			SepetSepetYumurta yums = yumartalar.FirstOrDefault(c => c.ProductId == ProductId);

			if (yums == null)
			{  // sepette yoktur...
				yums = new SepetSepetYumurta();
				yums.Adet = 1;
				yums.ProductId = ProductId;
				yums.Product = _dbContext.Products.Find(ProductId);
				yumartalar.Add(yums);
			}
			else
			{
				yums.Adet++;
			}


			string strs = JsonConvert.SerializeObject(yumartalar); // stringe dönüştür...
			HttpContext.Session.SetString("sepet", strs);

			return PartialView("_basketSummary", yumartalar);
		}
	}
}
