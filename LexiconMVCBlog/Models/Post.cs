using System;
using System.Collections.Generic;

namespace LexiconMVCBlog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public ICollection<PostComment> Comments { get; set; }
    }
}