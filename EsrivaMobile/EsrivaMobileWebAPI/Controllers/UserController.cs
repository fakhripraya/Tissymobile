using EsrivaMobileWebAPI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace EsrivaMobileWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        [Route("GetPFP")]
        public HttpResponseMessage GetPFP(string guid)
        {
            try
            {
                if (guid == "Unauthorized")
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }

                string strCurrentUserId = guid;

                var httpRequest = HttpContext.Current.Request;

                using (var DBContext = new esrivamobileEntities())
                {
                    var currentUser = DBContext
                        .dbusers
                        .Where(x => x.UserId == strCurrentUserId)
                        .FirstOrDefault();

                    var imagePath = currentUser.ProfilePicSrc;

                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return new HttpResponseMessage(HttpStatusCode.NotFound);
                    }

                    string fullPath = AppDomain.CurrentDomain.BaseDirectory + imagePath.Substring(imagePath.IndexOf("~") + 2);

                    if (!File.Exists(fullPath))
                    {
                        return new HttpResponseMessage(HttpStatusCode.NotFound);
                    }

                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    var fileStream = new FileStream(fullPath, FileMode.Open);
                    response.Content = new StreamContent(fileStream);
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("GetUserInfo")]
        public LoggedUserModel GetUserInfo()
        {
            string userId = User.Identity.GetUserId();

            using (var DBContext = new esrivamobileEntities())
            {
                var currentUser = DBContext
                        .dbusers
                        .Where(x => x.UserId == userId)
                        .FirstOrDefault();

                var userPodcastCount = DBContext
                        .dbpodcasts
                        .Where(x => x.UserId == userId)
                        .ToList().Count();

                var userFollowingCount = DBContext
                        .dbfollowings
                        .Where(x => x.UserId == userId)
                        .ToList().Count();

                var userFollowersCount = DBContext
                        .dbfollowers
                        .Where(x => x.UserId == userId)
                        .ToList().Count();
                
                LoggedUserModel newUser = new LoggedUserModel();

                newUser.UserId = User.Identity.GetUserId();
                newUser.Email = currentUser.Email;
                newUser.Name = currentUser.Name;
                if (currentUser.IsCustomRank == true)
                {
                    newUser.Rank = currentUser.Rank;
                }
                else
                {
                    if (userPodcastCount == 0 && userPodcastCount <= 99)
                    {
                        newUser.Rank = "Initiate";
                }
                    else if (userPodcastCount >= 100 && userPodcastCount <= 499)
                    {
                        newUser.Rank = "Adapt";
                    }
                    else if (userPodcastCount >= 500 && userPodcastCount <= 999)
                    {
                        newUser.Rank = "Veteran";
                    }
                    else if (userPodcastCount >= 1000 && userPodcastCount <= 2499)
                    {
                        newUser.Rank = "Commander";
                    }
                    else if (userPodcastCount >= 2500 && userPodcastCount <= 4999)
                    {
                        newUser.Rank = "General";
                    }
                    else if (userPodcastCount >= 5000 && userPodcastCount <= 9999)
                    {
                        newUser.Rank = "Lord";
                    }
                    else if (userPodcastCount >= 10000 && userPodcastCount <= 24999)
                    {
                        newUser.Rank = "HighLord";
                    }
                    else if (userPodcastCount >= 25000)
                    {
                        newUser.Rank = "Overlord";
                    }
                }

                if (currentUser.Location1 == null || currentUser.Location2 == null || currentUser.Location3 == null)
                {
                    newUser.Location = "Unknown";
                }
                else
                {
                    newUser.Location = currentUser.Location1 + " " + currentUser.Location2 + " " + currentUser.Location3;
                }
                newUser.About = currentUser.AboutMe;
                newUser.PodcastCount = userPodcastCount;
                newUser.FollowingCount = userFollowingCount;
                newUser.FollowersCount = userFollowersCount;

                return newUser;
            }
        }
    }
}
