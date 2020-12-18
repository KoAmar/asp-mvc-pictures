using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationMVC.Models
{
    public sealed class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Comment>().HasData(
        //        new Comment { Id = 1, ConnectedPostId = 1, CreatorLogin = "test", CreationDate = DateTime.Now, Text = "Test" },
        //        new Comment { Id = 2, ConnectedPostId = 1, CreatorLogin = "test2", CreationDate = DateTime.Now, Text = "Test2" },
        //        new Comment { Id = 3, ConnectedPostId = 1, CreatorLogin = "test3", CreationDate = DateTime.Now, Text = "Test3" }
        //        );
        //    modelBuilder.Entity<Post>().HasData(
        //        new Post {Id = 1,Title = "1",Text = "1",CreatorLogin = "test@gmail.com",CreationDate = DateTime.Now,
        //            PreviewImagePath = "d8bcab50-c7bf-4631-9fb0-9106177b7e1b_kotik_d_850_d_850.jpg"}
        //        );
        //}
    }
}