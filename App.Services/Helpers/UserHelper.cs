using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace App.Services.Helpers
{
    public class UserHelper : IUserHelper
    {
        #region Properties
       /// private readonly FindTheGarageContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructors
        public UserHelper(
                 IHttpContextAccessor httpContextAccessor
              //   FindTheGarageContext dbContext
           )
        {
            _httpContextAccessor = httpContextAccessor;
           // _dbContext = dbContext;
        }
        #endregion

        #region Public Methods

        public Guid userId()
        {
            if ((_httpContextAccessor.HttpContext?.User.Identity.IsAuthenticated).Value)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Guid.Parse(userId);
            }
            return Guid.Empty;
        }

        #endregion
    }
}
