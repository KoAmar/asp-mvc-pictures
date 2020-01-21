using System;
using Microsoft.AspNetCore.Http;

namespace WebApplicationMVC.ViewModels
{
    public class PostCreateViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string CreatorLogin { get; set; }
        public DateTime CreationDate { get; set; }
        public IFormFile Photo { get; set; }
    }
}
