using System;
using System.Collections.Generic;
using System.Text;

namespace Yasol.DigitalUser.Common.Core
{
    public class RequestContextImplementation : IRequestContext
    {
        public string RequestID => Guid.NewGuid().ToString();

        public string AppID => "app_id_test";

        public string ApiVersion => "1";
    }
}
