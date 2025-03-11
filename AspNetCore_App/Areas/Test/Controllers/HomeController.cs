using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_App.Areas.Test.Controllers
{
	[Area("Test")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
