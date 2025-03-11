using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_App.Controllers
{
	public class AjaxController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Search(string name)
		{

			// ajax requestlerde genelde response olarak json data dönülür...

			int deger = 0;
			Random rnd = new Random();
			deger = rnd.Next(0, 1000); //0 ile 1000 arası bir sayı üret

			// anonim tip
			var rsp = new
			{
				arananDeger = name,
				randomDeger = deger,
			};

			return Json(rsp);

		}

		public IActionResult JqueryIndex()
		{
			return View();
		}

		public IActionResult MyAjaxHelper()
		{
			return View();
		}

		public IActionResult OgrList()
		{
			var a = new { DersAdi = "C#", Kredi = 4 };
			var b = new { DersAdi = "Sql Server", Kredi = 4 };
			var c = new { DersAdi = "Java", Kredi = 2 };

			var list = new[] { a, b, c }.ToList();
			return Json(list);

		}
	}
}
