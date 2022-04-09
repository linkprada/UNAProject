using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNAProject.Core.Constants
{
    public class AuthorizationConstants
    {
        public const string DEFAULT_PASSWORD = "Pass@word1";

        // TODO: Change this to an environment variable
        public const string JWT_SECRET_KEY = "SecretKeyOfDoomThatMustBeAMinimumNumberOfBytes";

        public static class Roles
        {
            public const string ADMINISTRATORS = "Administrators";
        }
    }
}
