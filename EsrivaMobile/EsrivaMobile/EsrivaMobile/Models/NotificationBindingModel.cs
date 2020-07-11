using System;
using System.Collections.Generic;
using System.Text;

namespace EsrivaMobile.Models
{
    public class NotificationBindingModel
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public DateTime NotifDate { get; set; }
    }
}
