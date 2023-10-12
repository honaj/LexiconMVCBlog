using Microsoft.AspNetCore.Mvc;
using LexiconMVCBlog.Models;

namespace YourNamespace.Controllers
{
    /// <summary>
    /// Controller for handling blog-related actions.
    /// </summary>
    public class BlogController : Controller
    {
        private readonly BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Displays a list of all posts.
        /// </summary>
        /// <returns>The view containing the list of posts.</returns>
        public IActionResult Index()
        {
            var posts = _context.Posts.ToList();
            return View(posts);
        }
    }
}