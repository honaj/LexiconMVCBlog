using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LexiconMVCBlog.Models;
using YourNamespace;

namespace LexiconMVCBlog.Controllers
{
    public class PostCommentController : Controller
    {
        private readonly BlogContext _context;

        public PostCommentController(BlogContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var comments = _context.PostComments.ToList();
            return View(comments);
        }

        public IActionResult Create(int postId)
        {
            ViewBag.PostId = postId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostComment comment)
        {
            if (ModelState.IsValid)
            {
                _context.PostComments.Add(comment);
                _context.SaveChanges();
                return RedirectToAction("Details", "Post", new { id = comment.PostId });
            }
            return View(comment);
        }

        public IActionResult Edit(int id)
        {
            var comment = _context.PostComments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PostComment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(comment);
                _context.SaveChanges();
                return RedirectToAction("Details", "Post", new { id = comment.PostId });
            }
            return View(comment);
        }

        public IActionResult Delete(int id)
        {
            var comment = _context.PostComments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var comment = _context.PostComments.Find(id);
            _context.PostComments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("Details", "Post", new { id = comment.PostId });
        }
    }
}