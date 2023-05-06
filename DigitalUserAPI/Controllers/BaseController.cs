using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Yasol.DigitalUser.Common.Core;
using Yasol.DigitalUser.Common.Enums;

namespace Yasol.DigitalUser.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private const string SystemName = "DigitalUserApi";
        private const string RequestMsg = "Request";
        private const string ResponseMsg = "Response";
        private readonly IRequestContext requestContext;
        //private readonly TelemetryClient telemetryClient;

        public BaseController(
            IRequestContext requestContext 
            //TelemetryClient telemetryClient
            )
        {
            this.requestContext = requestContext ?? throw new ArgumentNullException(nameof(requestContext));
            //this.telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(requestContext));
        }

        public string AppId
        {
            get
            {
                return this.Request.Headers["appId"].FirstOrDefault();
            }
        }

        public string CorrelationId
        {
            get
            {
                return this.Request.Headers["correlationId"].FirstOrDefault() ?? Guid.NewGuid().ToString();
            }
        }

        protected IActionResult Success<T>(T data)
        {
            var response = new BaseApiResponse<T>()
            {
                RequestId = this.requestContext.RequestID,
                Status = ResponseStatus.Success,
                IsSuccess = true,
                Data = data
            };

            return this.StatusCode(StatusCodes.Status200OK, response);
        }

        protected BaseApiResponse<T> CreateApiResponse<T>(ResponseStatus status, T data)
        {
            return new BaseApiResponse<T>()
            {
                RequestId = this.requestContext.RequestID,
                Status = status,
                IsSuccess = status == ResponseStatus.Success ? true : false,
                Messages = status == ResponseStatus.Success ? "Successfully created" : "Failed to create a response",
                Data = data
            };
        }

        protected IActionResult UnauthorizedStatus401<T>(T data)
        {
            var response = new BaseApiResponse<T>()
            {
                RequestId = this.requestContext.RequestID,
                Status = ResponseStatus.Failure,
                IsSuccess = false,
                Messages = "Unauthorized Access",
                Data = data
            };
            return this.StatusCode(StatusCodes.Status401Unauthorized, response);
        }

        private NameValueCollection GetHeaders()
        {
            var headers = new NameValueCollection();

            this.Request.Headers.ToList().ForEach(item =>
            {
                headers.Add(item.Key, item.Value.FirstOrDefault());
            });

            return headers;
        }
    }
}
