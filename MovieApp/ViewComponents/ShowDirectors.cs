using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Context;

namespace MovieApp.ViewComponents
{
    public class ShowDirectors:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using(MovieContext context = new MovieContext())
            {
                var data = context.Directorss.Select(x => new
                {
                    id = x.Id,
                    name = x.FirstName + " " + x.LastName
                });
                var directorList = data.Select(x => new SelectListItem
                {
                    Value = x.id.ToString(),
                    Text = x.name
                }).ToList();
                ViewBag.DirectorSelectList=directorList;
                return View();
            }

            return View("~/Views/Shared/Components/ShowDirectors/Default.cshtml");

        }
    }
}
