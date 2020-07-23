using EsrivaMobileWebAPI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Xamarin.Forms;

namespace EsrivaMobileWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Files")]
    public class FilesController : ApiController
    {
        [HttpPost]
        [Route("UploadPFP")]
        public IHttpActionResult UploadPFP()
        {
            try
            {
                var strCurrentUserId = User.Identity.GetUserId();

                var httpRequest = HttpContext.Current.Request;

                if (httpRequest.Files.Count > 0)
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var uploadedFile = httpRequest.Files[file];

                        var fileName = uploadedFile
                            .FileName
                            .Split('\\')
                            .LastOrDefault()
                            .Split('/')
                            .LastOrDefault();

                        var folderCreate = HttpContext
                            .Current
                            .Server
                            .MapPath("~/Uploads/" + $"USER{strCurrentUserId}");

                        if (!Directory.Exists(folderCreate))
                        {
                            Directory.CreateDirectory(folderCreate);

                            var userGalleryFolderCreate = HttpContext
                                .Current
                                .Server
                                .MapPath("~/Uploads/" + $"USER{strCurrentUserId}/" + "UserGallery");

                            if (!Directory.Exists(userGalleryFolderCreate))
                            {
                                Directory.CreateDirectory(userGalleryFolderCreate);
                            }
                        }

                        var filePath = HttpContext
                            .Current
                            .Server
                            .MapPath("~/Uploads/" + $"USER{strCurrentUserId}/" + "UserGallery/" + fileName);

                        using (var DBContext = new esrivamobileEntities())
                        {
                            var currentUser = DBContext
                                .dbusers
                                .Where(x => x.UserId == strCurrentUserId)
                                .FirstOrDefault();

                            currentUser.ProfilePicSrc = "~/Uploads/" + $"USER{strCurrentUserId}/" + "UserGallery/" + fileName;
                            DBContext.SaveChanges();
                        }
                            uploadedFile.SaveAs(filePath);
                    }
                }
                return Content(HttpStatusCode.OK, "true");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
