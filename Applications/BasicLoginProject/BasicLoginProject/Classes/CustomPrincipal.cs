using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace BasicLoginProject.Classes
{
    public class CustomPrincipal : IPrincipal
    {
        private IIdentity _identity;
        private string[] _roles;
        public IIdentity Identity
        {
            get
            {
                return _identity;
            }
        }

        public bool IsInRole(string role)
        {
            return Array.BinarySearch(_roles, role) >= 0 ? true : false;
        }

        public CustomPrincipal(IIdentity identity, string[] roles)
        {
            this._identity = identity;
            this._roles = new string[roles.Length];
            roles.CopyTo(_roles, 0);
            Array.Sort(_roles);
        }
        // Checks whether a principal is in all of the specified set of 

        public bool IsInAllRoles(params string[] roles)
        {
            foreach (string searchrole in roles)
            {
                if (Array.BinarySearch(_roles, searchrole) < 0)
                    return false;
            }
            return true;
        }
        // Checks whether a principal is in any of the specified set of 

        public bool IsInAnyRoles(params string[] roles)
        {
            foreach (string searchrole in roles)
            {
                if (Array.BinarySearch(_roles, searchrole) > 0)
                    return true;
            }
            return false;
        }

    }
}