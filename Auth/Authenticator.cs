using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CoreNancySelfHostedNet.Auth
{
    public class Authenticator
    {
        public static ClaimsPrincipal AuthenticateToken(string token, string key)
        {
            string credentials = "super-secret-credentials-lol!";
            

            if (token == null || !token.Equals(credentials))
            {
                return null;
            }

            return new ClaimsPrincipal(new GenericIdentity(token, "stateless"));
        }
    }
}
