using Microsoft.AspNetCore.Mvc;
using YtBookStore.Models.Domain;
using YtBookStore.Repository.IRepository;

namespace YtBookStore.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService service;
        public GenreController(IGenreService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var data = service.GetAll();
            return View(data);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);

        }
        public IActionResult Edit(int id)
        {
            var record = service.FindById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = service.Update(model);
            if (result)
            {
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Error has occured on server side";
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var result = service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
