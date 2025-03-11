using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_App.Areas.Yonetim.Controllers
{

	// Area içerisinde controllerlara Area attrribute ile tanım yapmamız gerekiyor..
	[Area("Yonetim")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
