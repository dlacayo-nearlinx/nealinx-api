﻿
using Microsoft.EntityFrameworkCore;

namespace WebApplication3
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    namespace ConsoleApp.PostgreSQL
    {
        public class BloggingContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
            public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
            {
            }
        }

        public class Blog
        {
            public int BlogId { get; set; }
            public string Url { get; set; }
            public List<Post> Posts { get; set; }
        }
        public class Post
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public int BlogId { get; set; }
            public Blog Blog { get; set; }
        }
    }

}
