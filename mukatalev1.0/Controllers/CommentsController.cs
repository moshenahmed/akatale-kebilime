using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using mukatalev1._0.Models;

namespace mukatalev1._0.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RepliesController replies = new RepliesController();

        // GET: Comments
        public List<CommentReplyViewModel> Index(int PostId)
        {
            var comments = (from c in db.Comments
                            where c.PostId == PostId
                            select new CommentReplyViewModel
                            {
                                Comment = c,
                                UserTagComment = db.Users.FirstOrDefault(x => x.Id == c.UserId).UserName,
                                reply = c.Replies.ToList()
                            }).ToList();

            return comments;
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Create([Bind(Include = "Id,Text,CreatedAt, UserId")] Comment commentText, int PostId)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {
                var comment = new Comment
                {
                    Text = commentText.Text,
                    CreatedAt = DateTime.Now,
                    PostId = PostId,
                    UserId = db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name).Id

                };
                db.Comments.Add(comment);
                db.SaveChanges();
                //return PartialView("Details", Details(comment.Id));

                //Response.Redirect(Url.Action("Details","Posts", new { id = PostId}));
                Response.Redirect(Url.Action("Details", "Posts", new { id = PostId }));
            }

            RedirectToAction("Login", "Account", false);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Text,CreatedAt")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            System.Windows.Forms.MessageBox.Show("Are you sure You want to Delete this comment and all its replies");
            return RedirectToAction("DeleteConfirmed", new { id = comment.Id });
        }

        // POST: Comments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var comment = db.Comments.Find(id);
            //var reply = db.Replies.FirstOrDefault(x => x.CommentId == comment.Id);
            //db.Replies.Remove(reply);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return RedirectToAction("Details", "Posts", new { id = comment.PostId });
        }
        public ActionResult Validator()
        {
            System.Windows.Forms.MessageBox.Show("Are you sure You want to Delete this comment and all its replies");
            return RedirectToAction("Create");
        }

        public void PopUpWindow()
        {
            MessageBox.Show("Moshen");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}