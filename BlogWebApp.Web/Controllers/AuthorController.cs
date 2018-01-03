using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.ViewModel;

namespace BlogWebApp.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
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

        // Combining of GET and POST Create methods in this one - requirement of the 1st task
        public ActionResult Create(AuthorViewModel author, string action)
        {
            ViewBag.hobbies = GetHobbies();

            // Check for unique field NickName and validity of the model
            if (!_authorService.Exists(i => i.NickName == author.NickName) && action == "Create" && ModelState.IsValid)
            {
                author.Id = Guid.NewGuid();

                _authorService.Create(author);
                _authorService.Save();

                return RedirectToAction($"Details/{author.Id}");
            }

            // Validate NickName field if one is not unique
            if (action == "Create" && ModelState.IsValid)
            {
                ViewBag.error = "Author with such nickname is exists!";
                return View(author);
            }

            return View(author);
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