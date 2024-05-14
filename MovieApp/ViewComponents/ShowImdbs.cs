using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Context;

namespace MovieApp.ViewComponents
{
    public class ShowImdbs:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using(MovieContext context = new())
            {
                var data = context.Imdbs.Select(x => new
                {
                    id = x.Id,
                    imdbPoint = x.ImdbPoint
                });
                var ImdbPointList = data.Select(x => new SelectListItem
                {
                    Value = x.id.ToString(),
                    Text = x.imdbPoint.ToString()
                }).ToList();

                ViewBag.ImdbSelectList = ImdbPointList;
                return View();

            }
            return View("~/Views/Shared/Components/ShowImdbs/Default.cshtml");
        }
    }
}
