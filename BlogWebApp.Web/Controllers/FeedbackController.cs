using System;
using System.Linq;
using System.Web.Mvc;
using BlogWebApp.BLL.Services.Implementations;
using BlogWebApp.BLL.Services.Interfaces;
using BlogWebApp.ViewModel;

namespace BlogWebApp.Web.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController()
        {
            _feedbackService = new FeedbackService();
        }

        // GET: Feedback
        [HttpGet]
        public ActionResult Index()
        {
            var feedbacks = _feedbackService.GetAll().OrderByDescending(f => f.Date);

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
            {
                return View(item);
            }

            // Validation of unique field Author
            if (!_feedbackService.Exists(i => i.Author == item.Author))
            {
                item.Id = Guid.NewGuid();
            }
            else
            {
                ViewBag.error = "Author with such nickname is exists!";
                return View(item);
            }

            _feedbackService.Create(item);
            _feedbackService.Save();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var itemForEdit = _feedbackService.Get(id);

            return View(itemForEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FeedbackViewModel item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            _feedbackService.Update(item);
            _feedbackService.Save();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var itemForDelete = _feedbackService.Get(id);

            _feedbackService.Delete(itemForDelete.Id);
            _feedbackService.Save();

            return RedirectToAction("Index");
        }
    }
}