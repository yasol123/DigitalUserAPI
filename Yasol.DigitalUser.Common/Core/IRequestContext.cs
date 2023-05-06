using System;
using System.Collections.Generic;
using System.Text;

namespace Yasol.DigitalUser.Common.Core
{
    public interface IRequestContext
    {
        public string RequestID { get; }
        public string AppID { get; }
        public string ApiVersion { get; }
    }
}
