using System;
using System.Collections.Generic;
using System.Text;
using Yasol.DigitalUser.Model.Account;
namespace Yasol.DigitalUser.Common.Security
{
    public interface IAccountJwt
    {
        public string GetUserToken(UserAccount account);
    }
}
