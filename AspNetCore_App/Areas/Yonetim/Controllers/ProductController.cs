using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_App.Areas.Yonetim.Controllers
{
	[Area("Yonetim")]
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
