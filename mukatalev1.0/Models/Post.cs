using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static mukatalev1._0.Models.PostViewModel;

namespace mukatalev1._0.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public Markets Market { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Image { get; set; }

        public ICollection<Comment> Comments { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

    }
}