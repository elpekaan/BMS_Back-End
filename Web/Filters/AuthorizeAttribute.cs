using Business.Utilities.Security.Auth.Jwt.Interface;
using Infrastructure.Data.Postgres.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.Filters;

public class AuthorizeAttribute : TypeFilterAttribute
{
    public AuthorizeAttribute(params UserType[] roles) : base(typeof(AuthorizeFilter))
    {
        Arguments = new object[] { roles };
    }

    public class AuthorizeFilter : IAuthorizationFilter
    {
        private readonly UserType[] _roles;

        private readonly IClaimHelper _claimHelper;

        public AuthorizeFilter(IClaimHelper claimHelper, params UserType[] roles)
        {
            _roles = roles;

            _claimHelper = claimHelper;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthenticated = context.HttpContext.User.Identity?.IsAuthenticated;

            if (!isAuthenticated.HasValue || !isAuthenticated.Value)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                var userRole = _claimHelper.GetUserType();

                if (userRole.HasValue)
                {
                    if (_roles.Any())
                    {
                        if (_roles.Contains(userRole.Value))
                        {
                            return;
                        }
                    }
                }

                context.Result = new UnauthorizedResult();
            }
        }
    }
}