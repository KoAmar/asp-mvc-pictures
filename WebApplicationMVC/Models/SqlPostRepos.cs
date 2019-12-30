using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationMVC.Models
{
    public class SqlPostRepos : IPostRepository
    {
        private readonly AppDbContext _context;

        public SqlPostRepos(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public Post GetPost(int id)
        {
            return _context.Posts.Find(id);
        }

        public Post DeletePost(int id)
        {
            var post = _context.Posts.Find(id);

            if (post == null) return null;

            _context.Posts.Remove(post);
            _context.SaveChanges();

            return post;
        }

        public Post AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }

        public Post UpdatePost(Post postChanges)
        {
            var post = _context.Posts.Attach(postChanges);
            post.State = EntityState.Modified;
            _context.SaveChanges();
            return postChanges;
        }
    }
}