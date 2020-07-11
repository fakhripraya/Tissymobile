using System;

namespace EsrivaMobile.Models
{
    public class ForumReplyBindingModel
    {
        public string ReplyId { get; set; }
        public string ForumId { get; set; }
        public string AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }

    public class ArticleReplyBindingModel
    {
        public string ReplyId { get; set; }
        public string ArticleId { get; set; }
        public string AuthorId { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
    }
}