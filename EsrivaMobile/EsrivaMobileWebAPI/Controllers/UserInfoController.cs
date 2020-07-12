using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EsrivaMobileWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/UserInfo")]
    public class UserInfoController : ApiController
    {
    }
}
