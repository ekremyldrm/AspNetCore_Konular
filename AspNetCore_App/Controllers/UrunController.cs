using AspNetCore_App.Areas.Uygulama.Models;
using AspNetCore_App.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_App.Controllers
{
    public class UrunController : Controller
	{
		public UrunController()
		{
		}

		public IActionResult Index()
		{
			
			return View();
		}
	}
}
