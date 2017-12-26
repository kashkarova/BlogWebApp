using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BlogWebApp.BLL.Services.Implementations;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.ViewModel;

namespace BlogWebApp.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController()
        {
            _authorService = new AuthorService();
        }

        // GET: Author
        [HttpGet]
        public ActionResult Index()
        {
            return View(_authorService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var selectedAuthor = _authorService.Get(id);

            return View(selectedAuthor);
        }

        public ActionResult Create(AuthorViewModel author, string action)
        {
            ViewBag.hobbies = GetHobbies();

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!_authorService.Exists(i => i.NickName == author.NickName) && action == "Create")
            {
                author.Id = Guid.NewGuid();

                _authorService.Create(author);
                _authorService.Save();

                return RedirectToAction($"Details/{author.Id}");
            }

            ViewBag.error = "Author with such nickname is exists!";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var itemForEdit = _authorService.Get(id);

            return View(itemForEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuthorViewModel item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            _authorService.Update(item);
            _authorService.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            var itemForDelete = _authorService.Get(id);

            _authorService.Delete(itemForDelete.Id);
            _authorService.Save();

            return RedirectToAction("Index");
        }

        private IEnumerable<string> GetHobbies()
        {
            return new List<string>
            {
                "Eating",
                "Sleeping",
                "Coding",
                "Dancing",
                "Reading books",
                "Drawing"
            };
        }
    }
}