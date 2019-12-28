using System.Collections.Generic;

namespace WebApplicationMVC.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPost(int id);
        Post DeletePost(int id);
        Post AddPost(Post post);
        Post UpdatePost(Post post);
    }
}