using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationMVC.Models
{
    public class SqlCommentsRepos : ICommentsRepository
    {
        private readonly AppDbContext _context;

        public SqlCommentsRepos(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments;
        }

        public Comment GetComment(int id)
        {
            return _context.Comments.Find(id);
        }

        public Comment DeleteComment(int id)
        {
            var comment = _context.Comments.Find(id);

            if (comment == null) return null;

            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return comment;

        }

        public Comment AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        public Comment UpdateComment(Comment commentChanges)
        {
            var post = _context.Comments.Attach(commentChanges);
            post.State = EntityState.Modified;
            _context.SaveChanges();
            return commentChanges;
        }
    }
}
