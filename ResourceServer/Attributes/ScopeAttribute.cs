using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ResourceServer.Attributes
{
    public class ScopeAttribute : AuthorizeAttribute
    {
        string[] _scopes;
        static string _scopeClaimType = "urn:oauth:scope";

        public static string ScopeClaimType
        {
            get { return _scopeClaimType; }
            set { _scopeClaimType = value; }
        }

        public ScopeAttribute(params string[] scopes)
        {
            if (scopes == null)
            {
                throw new ArgumentNullException("scopes");
            }

            _scopes = scopes;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var grantedScopes = ClaimsPrincipal.Current.FindAll(_scopeClaimType).Select(c => c.Value).ToList();

            foreach (var scope in _scopes)
            {
                if (!grantedScopes.Contains(scope))
                {
                    return false;
                }
            }

            return true;
        }
    }
}