using System;
using System.Linq;
using System.Web.Mvc;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.ViewModel.Models;

namespace BlogWebApp.Web.Controllers
{
    public class FeedbackController : Controller
    {
        public FeedbackController(IFeedbackService feedbackService)
        {
            FeedbackService = feedbackService;
        }

        private IFeedbackService FeedbackService { get; }

        // GET: Feedback
        [HttpGet]
        public ActionResult Index()
        {
            var feedbacks = FeedbackService.GetAll().OrderByDescending(f => f.Date);

            return View(feedbacks);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackViewModel item)
        {
            if (!ModelState.IsValid)
                return View(item);

            // Validation of unique field Author
            if (!FeedbackService.Exists(i => i.Author == item.Author))
            {
                item.Id = Guid.NewGuid();
            }
            else
            {
                ViewBag.error = "Author with such nickname is exists!";
                return View(item);
            }

            FeedbackService.Create(item);
            FeedbackService.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var itemForEdit = FeedbackService.Get(id);

            return View(itemForEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FeedbackViewModel item)
        {
            if (!ModelState.IsValid)
                return View(item);

            FeedbackService.Update(item);
            FeedbackService.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var itemForDelete = FeedbackService.Get(id);

            FeedbackService.Delete(itemForDelete.Id);
            FeedbackService.Save();

            return RedirectToAction("Index");
        }
    }
}