using System;
using System.Linq;
using System.Web.Mvc;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.ViewModel;

namespace BlogWebApp.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        // GET: Article
        [HttpGet]
        public ActionResult Index()
        {
            var articles = _articleService.GetAll().OrderByDescending(a => a.Date);

            return View(articles);
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

            // Validation of unique field Title
            if (!_articleService.Exists(i => i.Title == item.Title))
            {
                item.Id = Guid.NewGuid();
            }
            else
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

            _articleService.Update(item);
            _articleService.Save();

            return RedirectToAction("Index");
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