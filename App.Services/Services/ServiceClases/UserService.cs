using App.Services.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace App.Services.Services.ServiceClases
{
    public class UserService : IUserService
    {
        #region Properties
       /// private readonly FindTheGarageContext _dbContext;
        private readonly UserManager<App.DataAccess.Identity.AspNetUsers> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        

        #endregion

        #region Constructors
        public UserService(
             ///    FindTheGarageContext dbContext,
                 UserManager<App.DataAccess.Identity.AspNetUsers> userManager,
                 IHttpContextAccessor httpContextAccessor,
                 IMapper mapper
                
           )
        {
          ///  _dbContext = dbContext;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
           

        }
        #endregion

        #region Public Methods

        //public async Task<DataAccess.Models.RefreshToken> GetRefreshToken(string UserId)
        //{

        //    var refreshDbToken = _dbContext.RefreshToken.SingleOrDefault(t => t.UserId == UserId);

        //    if (refreshDbToken != null)
        //    {
        //        _dbContext.RefreshToken.Remove(refreshDbToken);
        //        await _dbContext.SaveChangesAsync();
        //    }

        //    var newRefreshToken = new DataAccess.Models.RefreshToken
        //    {
        //        UserId = UserId,
        //        Token = Guid.NewGuid().ToString(),
        //        IssuedUtc = DateTime.UtcNow,
        //        ExpiresUtc = DateTime.Now.AddDays(25)
        //    };

        //    _dbContext.RefreshToken.Add(newRefreshToken);
        //    await _dbContext.SaveChangesAsync();

        //    return newRefreshToken;
        //}

        //public async Task<UserIdentity> GetRefreshTokenUser(string token)
        //{

        //    var UserId = _dbContext.RefreshToken.SingleOrDefault(t => t.Token == token
        //      && t.ExpiresUtc < DateTime.UtcNow);
        //    if (UserId == null) { throw new Exception("Refresh Token Expired.please Re-login"); }
        //    var user = _dbContext.Users.SingleOrDefault(u => u.Id == UserId.UserId);
        //    if (user == null)
        //    {
        //        throw new Exception("User not exist");
        //    }
        //    return user;
        //}

        #endregion
        #region Helpers

        // ADD HERE

        #endregion
    }
}
