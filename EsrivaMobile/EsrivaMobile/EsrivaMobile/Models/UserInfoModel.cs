using System;
using System.Collections.Generic;
using System.Text;

namespace EsrivaMobile.Models
{
    public class LoggedUserInfoModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Rank { get; set; }
        public string PhoneNumber { get; set; }
        public string AboutMe { get; set; }
        public string ProfilePicSrc { get; set; }
        public string access_token { get; set; }
        public DateTime expires_in { get; set; }
        public DateTime issued { get; set; }
        public DateTime expires { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDelete { get; set; }
    }
}
