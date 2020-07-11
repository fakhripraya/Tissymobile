using System;
using System.Collections.Generic;
using System.Text;

namespace EsrivaMobile.Models
{
    public class ForumBindingModel
    {
        public int ForumId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ProfilePicSrc { get; set; }
        public DateTime PostDate { get; set; }
        public int TopicId { get; set; }
        public string Topic { get; set; }
        public string ForumContent { get; set; }
        public string Attatchment { get; set; }
        public decimal ViewNumber { get; set; }
        public List<ForumReplyBindingModel> Replies { get; set; }
    }
}
