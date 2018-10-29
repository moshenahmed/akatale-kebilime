using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mukatalev1._0.Models
{
    public class JobTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public  string JobDescription { get; set; }
        public string Image { get; set; }
        public int MainBid { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}