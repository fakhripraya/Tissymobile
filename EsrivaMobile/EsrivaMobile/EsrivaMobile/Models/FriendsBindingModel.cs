using System;
using System.Collections.Generic;
using System.Text;

namespace EsrivaMobile.Models
{
    public class FriendsBindingModel
    {
        public int FriendId { get; set; }
        public int UserId { get; set; }
        public string FriendName { get; set; }
        public string ProfilePicSrc { get; set; }
    }
}
