using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mukatalev1._0.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("CommentId")]
        public virtual Comment Comment { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}