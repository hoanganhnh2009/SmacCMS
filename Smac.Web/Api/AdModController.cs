using Smac.Service;
using Smac.Web.App_Start;
using Smac.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Smac.Web.Api
{
    [RoutePrefix("api/admod")]
    public class AdModController : ApiControllerBase
    {
        public AdModService _service;
        public ApplicationUserManager userManager;

        public AdModController(IErrorService errorService) : base(errorService)
        {
        }

        [Route("getmod")]
        [HttpGet]
        public HttpResponseMessage GetByUser(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var user = userManager.FindByNameAsync(User.Identity.Name);
                var responseData = _service.GetAdmodByUser(user.Result);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}