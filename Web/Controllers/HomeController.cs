using Data.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICar _cars;
        private readonly IGeneralInfo _general;
        private readonly ICategory _category;
        private readonly IComment _comment;

        public HomeController(ICar car, ICategory category, IGeneralInfo general, ILogger<HomeController> logger, IComment comment)
        {
            _cars = car;
            _category = category;
            _general = general;
            _logger = logger;
            _comment = comment;

        }

        public IActionResult Index()
        {
            var Model = new IndexModel()
            {
                Cars = _cars.GetAll(),
                Categories = _category.GetAll(),
                general = _general.GetById(1),
                Comments = _comment.GetAll()
            };
            return View(Model);
        }
        public IActionResult Cars(int id = 0, int page = 1)
        {


            var Model = new IndexModel()
            {
                Cars = _cars.GetAll(),
                Categories = _category.GetAll(),
                general = _general.GetById(1),
                Comments = _comment.GetAll(),
            };

            if (id != 0)
            {
                Model.Cars = _cars.GetByCategoryId(id);
                Model.category_control = id;
                TempData["category"] = "true";
            }
            return View(Model);
        }
        public IActionResult carDetails(int id)
        {
            return View(new CarDetailsModel() { car = _cars.GetById(id), general = _general.GetById(1) });
        }
        public IActionResult About()
        {
            return View(new IndexModel() { general = _general.GetById(1) });
        }
        public IActionResult Contact()
        {
            return View(new IndexModel() { general = _general.GetById(1) });
        }



    }
}
