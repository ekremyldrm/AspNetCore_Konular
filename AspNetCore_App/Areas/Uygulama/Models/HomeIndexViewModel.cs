using AspNetCore_App.Models.Entities;

namespace AspNetCore_App.Areas.Uygulama.Models
{
    public class HomeIndexViewModel
    {
        public List<Product> Vitrins { get; set; }

        public List<Product> EnCokSatans { get; set; }
    }
}
