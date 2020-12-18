using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationMVC.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CreatorLogin { get; set; }
        public DateTime CreationDate { get; set; }
        public int ConnectedPostId { get; set;  }
        public string Text{ get; set; }
    }
}
