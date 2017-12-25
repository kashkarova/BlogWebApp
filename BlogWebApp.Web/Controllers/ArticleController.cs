using System;
using System.Web.Mvc;
using BlogWebApp.BLL.Services.Implementations;
using BlogWebApp.BLL.Services.Interfaces;

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
        public ActionResult Index()
        {
            return View(_articleService.GetAll());
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