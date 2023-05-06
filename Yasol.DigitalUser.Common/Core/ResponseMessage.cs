using System;
using System.Collections.Generic;
using System.Text;
using Yasol.DigitalUser.Common.Enums;

namespace Yasol.DigitalUser.Common.Core
{
    public class ResponseMessage
    {
        public string MessageCode { get; set; }
        public ResponseMessageType MessageType { get; set; }
        public string MessageText { get; set; }
    }
}
