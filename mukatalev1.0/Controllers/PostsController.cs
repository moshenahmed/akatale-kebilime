using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using mukatalev1._0.Models;

namespace mukatalev1._0.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private CommentsController comment = new CommentsController();

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.OrderByDescending(x => x.CreatedAt).ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            var PostId = post.Id;
            var PostcommentReply = comment.Index(PostId);
            
            if(PostcommentReply==null)
            {
                return View(post);
            }
            
            var postCommentView = new PostCommentReplyViewModel
            {
                Post = post,
                UserTag = db.Users.FirstOrDefault(x => x.Id == post.UserId).UserName,
                CommentReply = PostcommentReply
                
            };
            return View("../ViewModels/PostCommentReplyViewModel", postCommentView);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            if (!User.Identity.IsAuthenticated) {
                return RedirectToAction("Login", "Account");
                    }
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Price,Market,Image")] PostViewModel post, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null)
            {
                var Image = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), Image);
                file.SaveAs(path);
                string RandomFileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".jpg";
                var path2 = Path.Combine(Server.MapPath("~/Images"), RandomFileName);
                System.IO.File.Move(path, path2);
                file.SaveAs(path2);
                System.IO.File.Delete(path);
                var NewPost = new Post
                { 
                    Title = post.Title,
                    Description = post.Description,
                    Price = post.Price,
                    Market = post.Market,
                    Image = RandomFileName,
                    CreatedAt = DateTime.Now,
                    Contact = post.Contact,
                    UserId = db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name).Id
                };                
                db.Posts.Add(NewPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Validator");
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Price,Market,CreatedAt,Image")] Post post, int id)
        {
            if (ModelState.IsValid)
            {
                var Editedpost = db.Posts.Find(id);
                var NewPost = new Post
                {
                    Id = id,
                    Title = post.Title,
                    Description = post.Description,
                    Price = post.Price,
                    CreatedAt = Editedpost.CreatedAt,
                    Image = Editedpost.Image,
                    Contact = post.Contact,
                    UserId = Editedpost.UserId
                };
                
                db.Entry(NewPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            var path = Path.Combine(Server.MapPath("~/Images"), post.Image);
            System.IO.File.Delete(path);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");    
        }
        public ActionResult Validator()
        {
            System.Windows.Forms.MessageBox.Show("Please upload the file of your produce!");    
                return RedirectToAction("Create");
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
