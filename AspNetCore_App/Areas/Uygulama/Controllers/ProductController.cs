using AspNetCore_App.Areas.Uygulama.Models;
using AspNetCore_App.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspNetCore_App.Areas.Uygulama.Controllers
{
	[Area("Uygulama")]
	public class ProductController : Controller
	{

		NorthwindDbContext _dbContext;
		public ProductController(NorthwindDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IActionResult Index(int id)
		{
			// Fİnd pk'ya göre nesne döner....
			ViewBag.CategroyName = _dbContext.Categories.Find(id).CategoryName;

			return View(_dbContext.Products.Where(c => c.CategoryId == id).ToList());
		}

		public IActionResult Detail(int id)
		{
			// productIdye göre produc'i bul...
			Product product = _dbContext.Products.Find(id);

			List<int> ids = ReadCookies(); // ckookide id varsa getir...

			// bu id'lere göre productları bul...

			#region "açıklama

			/*
			 *	Detay saufamda 3 adet model yapısı bulunmakta
			 *	1.urun
			 *	2.ürünün kategoriId si ve kateogrisinin adı
			 *	3. son gezilen ürünler.
			 *	viewların tek bir modeli olabildiği için bu 3 veri aynı anda view bind edemeyiz. 
			 *	1. yol olarak ayırı ayrı viewbag,viewdata gibi nesneler ile 3 ayrı modeli taşıyabiliriz..
			 *	2. yol olarak view özel bir viewmodel yazarak verileri view'a taşıyabiliriz...bu 3 model viewmodelde kapsüllenerek viewa bind edilir...
			 *	Model klasörüne ProductDetailViewModel sınıfı ekliyoruz...
			*/
			#endregion

			ids.Remove(id);// incelediğimiz ürünü göstermeyelim...

						   // c => ids.Contains(c.ProductId) ids listesinde productId geçeleri al....
			List<Product> gezilenProducts = _dbContext.Products.Where(c => ids.Contains(c.ProductId)).ToList();


			//ViewBag.CategoryId = product.CategoryId;
			//ViewBag.CategoryName = _dbContext.Categories.Find(product.CategoryId).CategoryName;


			// cookieye yaz..
			WriteCookies(id);


			ProductDetailViewModel vm = new ProductDetailViewModel();
			vm.Product = product;
			vm.SonGezilenler = gezilenProducts;
			vm.Category = _dbContext.Categories.Find(product.CategoryId);

			return View(vm);
		}

		[NonAction]
		private List<int> ReadCookies()
		{
			List<int> lists = new List<int>();
			string? idss = HttpContext.Request.Cookies["songezilen"];
			if (idss != null)
			{
				lists = JsonConvert.DeserializeObject<List<int>>(idss); // stringi listeye dönüştür...
			}

			return lists;
		}


		[NonAction]
		private void WriteCookies(int ProductId)
		{

			// id yazılır...
			List<int> lists = new List<int>();

			//if (HttpContext.Request.Cookies["songezilen"] != null) // cookide varsa
			//{
			//	lists = JsonConvert.DeserializeObject<List<int>>(HttpContext.Request.Cookies["songezilen"]); // çıkar
			//}
			string? idss = HttpContext.Request.Cookies["songezilen"];
			if (idss != null)
			{
				lists = JsonConvert.DeserializeObject<List<int>>(idss);
			}

			if (!lists.Contains(ProductId)) // eğer listede yoksa listeye ekle....
			{
				lists.Add(ProductId);
			}

			lists = lists.Take(5).ToList(); // 5 aadet eklesin...

			// veriyi json olarak serilize et...
			idss = JsonConvert.SerializeObject(lists);
			CookieOptions opts = new CookieOptions();
			opts.Expires = DateTime.Now.AddDays(7); // veriyi 1 hafta trayıcıda sakla...
			HttpContext.Response.Cookies.Append("songezilen", idss, opts);

		}
	}
}
