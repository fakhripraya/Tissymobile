using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsrivaMobileWebAPI.Models
{
    public class LoggedUserModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Rank { get; set; }
        public string Location { get; set; }
        public string About { get; set; }
        public int PodcastCount { get; set; }
        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }
    }
}