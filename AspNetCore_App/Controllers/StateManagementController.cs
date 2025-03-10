using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AspNetCore_App.Controllers
{
	public class StateManagementController : Controller
	{

		public IActionResult javascript()
		{
			return View();
		}

		public IActionResult Oturum()
		{
			return View();
		}


		int sayac = 0;

		[HttpPost] // bu parametre serverdan gelen inputlardan name adi olandır...
				 
		public IActionResult Oturum(string name, string soyadi) // parametre ismiyle yakabildiğimiz gibi
		{
			// FormCollection ile formdan gelen inputlar yakalabilir..
			// model ile formdan gelen inputları yakalamaktır. AspNetCore_EfCore prıjesi kullanici kayit örneğinde mevcut...
			string _adi = name;
			string _soyadi = soyadi;

			//HttpContext.





			// önce sessionda sayac var mı?
			if (this.HttpContext.Session.GetInt32("syc") != null) // syc sessioni varsa...
			{
				sayac = (int)this.HttpContext.Session.GetInt32("syc"); // sesiondan değeri al...
			}

			sayac++;

			this.HttpContext.Session.SetInt32("syc", sayac); // sayac değişkenini sessionda sakla...


			return View(sayac);
		}


		public IActionResult Kuki()
		{

			return View();
		}


		[HttpPost]
		public IActionResult Kuki(IFormCollection c) // metodu overload ediyoruz. get metodu ile karışmasın diye
		{
			// Request=> okurken

			string _adi = c["adi"];
			string _soyadi = c["soyadi"];

			string kukistr = "";
			if (this.HttpContext.Request.Cookies.TryGetValue("syc",out kukistr)) // kuki var mı?
			{
				sayac = int.Parse(kukistr); // convert sınıfı dönüşüm yapar...	
				sayac++;
			}

			CookieOptions options = new CookieOptions();
			//options.Expires = DateTime.Now.AddMinutes(1); // kuki tarayıcıda 1 dakika saklansın...
			options.Expires = DateTime.Now.AddDays(1); // kuki tarayıcıda 1 gün saklansın...

			// Response => yazarken
			this.HttpContext.Response.Cookies.Append("syc", sayac.ToString(),options); // kukiyi yazıyoruz
			return View(sayac); // geriye Index view'i dön...
		}
	}
}
