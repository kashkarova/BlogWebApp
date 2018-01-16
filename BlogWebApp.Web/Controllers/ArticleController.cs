using System;
using System.Linq;
using System.Web.Mvc;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.ViewModel.Models;

namespace BlogWebApp.Web.Controllers
{
    public class ArticleController : Controller
    {
        public ArticleController(IArticleService articleService, ITagService tagService)
        {
            ArticleService = articleService;
            TagService = tagService;
        }

        private IArticleService ArticleService { get; }

        private ITagService TagService { get; }

        // GET: Article
        [HttpGet]
        public ActionResult Index()
        {
            var articles = ArticleService.GetAll().OrderByDescending(a => a.Date).ToList();

            foreach (var article in articles)
            {
                var hashTags = TagService.GetAllTagTitles(t => t.ArticleId == article.Id).ToList();

                if (hashTags.Count == 0)
                    continue;

                article.HashTags = hashTags;
            }

            return View(articles);
        }

        public ActionResult FilterArticlesByTag(string hashTag)
        {
            var articles = TagService.GetArticlesByTag(hashTag);
            ViewData["tag"] = hashTag;

            foreach (var article in articles)
            {
                var hashTags = TagService.GetAllTagTitles(t => t.ArticleId == article.Id).ToList();

                if (hashTags.Count == 0)
                    continue;

                article.HashTags = hashTags;
            }

            return View(articles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleViewModel item, string hashTags)
        {
            if (!ModelState.IsValid)
                return View(item);

            // Validation of unique field Title
            if (!ArticleService.Exists(i => i.Title == item.Title))
            {
                item.Id = Guid.NewGuid();
            }
            else
            {
                ViewBag.error = "Such title is exists!";
                return View(item);
            }

            var tagTitlesList = hashTags.Split(' ').ToList();

            var tagList = tagTitlesList.Select(tagTitle => new TagViewModel {Title = tagTitle}).ToList();

            ArticleService.Create(item, tagList);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var itemForEdit = ArticleService.Get(id);

            return View(itemForEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleViewModel item)
        {
            if (!ModelState.IsValid)
                return View(item);

            ArticleService.Update(item);
            ArticleService.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            var itemForDelete = ArticleService.Get(id);
            ArticleService.Delete(itemForDelete.Id);
            ArticleService.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Votation(bool? havePets)
        {
            return PartialView(havePets == true ? "VotationTrue" : "VotationFalse");
        }
    }
}