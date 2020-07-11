using System;
using System.Collections.Generic;
using System.Text;

namespace EsrivaMobile.Models
{
    public class ArticleBindingModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime PostDate { get; set; }
        public int TopicId { get; set; }
        public string Topic { get; set; }
        public string ArticleContent { get; set; }
        public string Attatchment { get; set; }
        public string Thumbnail { get; set; }
        public decimal ViewNumber { get; set; }
        public List<ArticleReplyBindingModel> Replies { get; set; }
    }
}
