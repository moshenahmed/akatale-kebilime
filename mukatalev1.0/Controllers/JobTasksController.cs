using mukatalev1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mukatalev1._0.Controllers
{
    public class JobTasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: JobTasks
        public ActionResult JobTasks()
        {

            return View("JobTasks",db.JobTasks.ToList());
        }

        // GET: JobTasks/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobTasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobTasks/Create
        [HttpPost]
        public ActionResult Create(JobTaskViewModel jobtask, HttpPostedFileBase file)
        {
            var userid = db.Users.FirstOrDefault(x => x.FullName == User.Identity.Name).Id;
            
            var NewJob = new JobTask
            {
                Title = jobtask.Title,
                JobDescription = jobtask.JobDescription,
                MainBid = jobtask.MainBid,
                UserId = userid,
                Date = DateTime.Now,
                Image =  new PostsController().FileUpload(file)
            };

            db.JobTasks.Add(NewJob);
            db.SaveChanges();
            return RedirectToAction("JobTask");
        }

        // GET: JobTasks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobTasks/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobTasks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobTasks/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
