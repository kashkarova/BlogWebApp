using System;
using System.Web.Mvc;
using BlogWebApp.BLL.Services.Implementations;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.ViewModel;

namespace BlogWebApp.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController()
        {
            _articleService = new ArticleService();
        }

        // GET: Article
        [HttpGet]
        public ActionResult Index()
        {
            return View(_articleService.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleViewModel item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }


            if (_articleService.Exists(i => i.Title == item.Title))
            {
                ViewBag.error = "Such title is exists!";
                return View(item);
            }

            _articleService.Create(item);
            _articleService.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var itemForEdit = _articleService.Get(id);

            return View(itemForEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleViewModel item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            if (!_articleService.Exists(i => i.Title == item.Title))
            {
                _articleService.Update(item);
                _articleService.Save();

                return RedirectToAction("Index");
            }

            ViewBag.error = "Such title is exists!";
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            var itemForDelete = _articleService.Get(id);
            _articleService.Delete(itemForDelete.Id);
            _articleService.Save();

            return RedirectToAction("Index");
        }
    }
}