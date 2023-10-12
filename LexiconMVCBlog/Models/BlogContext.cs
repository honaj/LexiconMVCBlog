using Microsoft.EntityFrameworkCore;
using LexiconMVCBlog.Models;

namespace YourNamespace
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
            Posts = Set<Post>();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
    }
}