using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mukatalev1._0.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
    }
}