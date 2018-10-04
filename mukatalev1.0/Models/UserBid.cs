using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mukatalev1._0.Models
{
    public class UserBid
    {
        public int Id { get; set; }
        public int MyBid { get; set; }
        public int JobTaskId { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser  User { get; set; }
        public virtual JobTask JobTask { get; set; }
    }
}