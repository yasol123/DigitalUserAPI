using System;
using System.Collections.Generic;
using System.Text;
using Yasol.DigitalUser.Common.Enums;

namespace Yasol.DigitalUser.Common.Core
{
    public class BaseApiResponse<TData>
    {
        public string RequestId { get; set; }
        public ResponseStatus Status { get; set; }
        public string Messages { get; set; }
        public bool IsSuccess { get; set;}
        public TData Data { get; set; }

    }
}
