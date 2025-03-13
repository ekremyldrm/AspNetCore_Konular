using AspNetCore_App.Models.Entities;

namespace AspNetCore_App.Areas.Uygulama.Models
{
    public class SepetSepetYumurta
    {
        public int ProductId { get; set; }
        public int Adet { get; set; }

        public Product Product { get; set; }
    }
}