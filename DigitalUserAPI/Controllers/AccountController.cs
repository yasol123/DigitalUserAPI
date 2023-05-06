using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yasol.DigitalUser.Model.Account;
using Yasol.DigitalUser.Common.Security;
using Yasol.DigitalUser.API.Controllers;
using Yasol.DigitalUser.Common.Enums;
using Yasol.DigitalUser.Common.Core;

namespace DigitalUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountJwt accountJWT;
        
        public AccountController(
            IRequestContext requestContext,
            //Microsoft.ApplicationInsights.TelemetryClient telemetryClient,
            IAccountJwt accountJwt):base(requestContext)
                //, telemetryClient)
        {
            this.accountJWT = accountJwt ?? throw new ArgumentNullException(nameof(this.accountJWT));
        }

        [HttpPost("userCredentials")]
        public BaseApiResponse<string> GetUserToken([FromBody] UserAccount account)
        {
            var response = this.accountJWT.GetUserToken(account);
            return this.CreateApiResponse<string>(ResponseStatus.Success, response);
        }

        [HttpGet]
        public IActionResult GetAccountDetail([FromHeader] string UserToken)
        {
    
            return this.Ok();
        }
    }
}
