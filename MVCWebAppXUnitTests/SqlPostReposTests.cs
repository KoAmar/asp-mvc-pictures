using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models;
using Xunit;

namespace MVCWebAppXUnitTests
{
    public class SqlPostReposTests
    {
        [Fact]
        public void ObjNotNullTest()
        {
            var postRepository = GetPostRepository();
            var post = new Post()
            {
                Id = 1,
                Title = "Title",
                CreationDate = DateTime.Now,
                CreatorLogin = "Test",
                Text = "Test text",
            };

            var savedPost = postRepository.AddPost(post);

            var count = postRepository.GetAllPosts().Count();
            Assert.Equal(1, count);
        }

        private IPostRepository GetPostRepository()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            return new SqlPostRepos(new AppDbContext(options));
        }
    }
}
