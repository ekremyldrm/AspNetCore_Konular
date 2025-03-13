using AspNetCore_App.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_App.Areas.Uygulama.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        NorthwindDbContext _dbContext;
        public CategoriesViewComponent(NorthwindDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_dbContext.Categories.ToList());
        }
    }
}
