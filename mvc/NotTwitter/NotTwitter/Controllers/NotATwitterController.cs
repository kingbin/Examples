using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NotTwitter.Models;

namespace NotTwitter.Controllers
{   
    public class NotATwitterController : Controller
    {
		private readonly INotATweetRepository notatweetRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public NotATwitterController() : this(new NotATweetRepository())
        {
        }

        public NotATwitterController(INotATweetRepository notatweetRepository)
        {
			this.notatweetRepository = notatweetRepository;
        }

        //
        // GET: /NotATwitter/

        public ViewResult Index()
        {
            return View(notatweetRepository.All);
        }

        //
        // GET: /NotATwitter/Details/5

        public ViewResult Details(int id)
        {
            return View(notatweetRepository.Find(id));
        }

        //
        // GET: /NotATwitter/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /NotATwitter/Create

        [HttpPost]
        public ActionResult Create(NotATweet notatweet)
        {
            if (ModelState.IsValid) {
                notatweetRepository.InsertOrUpdate(notatweet);
                notatweetRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /NotATwitter/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(notatweetRepository.Find(id));
        }

        //
        // POST: /NotATwitter/Edit/5

        [HttpPost]
        public ActionResult Edit(NotATweet notatweet)
        {
            if (ModelState.IsValid) {
                notatweetRepository.InsertOrUpdate(notatweet);
                notatweetRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /NotATwitter/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(notatweetRepository.Find(id));
        }

        //
        // POST: /NotATwitter/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            notatweetRepository.Delete(id);
            notatweetRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                notatweetRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

