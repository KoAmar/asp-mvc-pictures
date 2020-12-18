using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.ViewModels
{
    public class PostDetailsAndCommentsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string CreatorLogin { get; set; }
        public DateTime CreationDate { get; set; }
        public string PreviewImagePath { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public Comment NewComment { get; set; }
    }
}
