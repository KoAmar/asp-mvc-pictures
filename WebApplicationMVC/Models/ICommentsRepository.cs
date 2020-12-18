using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMVC.Models
{
    public interface ICommentsRepository
    {
        IEnumerable<Comment> GetAllComments();
        Comment GetComment(int id);
        Comment DeleteComment(int id);
        Comment AddComment(Comment comment);
        Comment UpdateComment(Comment commentChanges);
    }
}
