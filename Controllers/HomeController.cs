using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Entities;
using NewsApp.Services;
using NewsApp.ViewModels;

namespace NewsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsData _newsData;
        private readonly IGreeter _greeter;

        public HomeController(INewsData newsData, IGreeter greeter)
        {
            _newsData = newsData;
            _greeter = greeter;
        }

        public async Task<ViewResult> Index()
        {
            var news = await _newsData.GetAll();

            var model = new HomePageViewModel
            {
                Messages = news,
                CurrentGreeting = _greeter.GetGreeting()
            };

            return View(model);
        }

        public IActionResult Details(string id)
        {
            var entity = _newsData.Get(id);

            if (entity == null)
                return RedirectToAction("Index");

            var model = new NewsDocViewModel();
            model.Id = entity._id;
            model.Main = entity.lead_paragraph;
            model.Type = entity.newsType;

            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NewsDocViewModel doc)
        {
            if (ModelState.IsValid)
            {
                var newsDoc = new NewsDoc
                {
                    lead_paragraph = doc.Main,
                    newsType = doc.Type
                };

                _newsData.Add(newsDoc);

                doc.Id = newsDoc._id;
                return RedirectToAction("Details", new { id = newsDoc._id });
            }

            return View();
        }
    }
}