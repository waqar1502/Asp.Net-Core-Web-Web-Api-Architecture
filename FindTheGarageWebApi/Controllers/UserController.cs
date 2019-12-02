using System;
using System.Security.Claims;
using System.Threading.Tasks;
using App.Models;
using App.Models.AppModels;
using App.Models.CommonModels;
using App.Services.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FindTheGarageWebApi.Controllers
{
    [Authorize]
    [Route("api/v1/user")]
    public class UserController : ApiBaseController
    {
        #region Constants
        private const string RegisterSuccessDetail = "User has been registered successfully.";
        private const string AlreadyexistUser = "User already exists. Please try another email address.";
        private const string NoexistUser = "User does not exists. Please register to continue.";
        private const string AlreadyexistUserName = "UserName already exists. Please try another username.";
        #endregion

        #region Properties
        private readonly IJwtFactory _jwtFactory;
        private readonly IMapper _mapper;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly UserManager<App.DataAccess.Identity.AspNetUsers> _userManager;
       // private readonly IUserService _userService;
        #endregion

        #region Constructors
        public UserController(
            IJwtFactory jwtFactory,
            IMapper mapper,
            IOptions<JwtIssuerOptions> jwtOptions,
            UserManager<App.DataAccess.Identity.AspNetUsers> userManager
           // IUserService userService
        )
        {
            _jwtFactory = jwtFactory;
            _mapper = mapper;
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
          //  _userService = userService;
        }
        #endregion

        #region Public Methods

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(typeof(SuccessViewModel), Constants.Http200)]
        public IActionResult Register(
           [FromBody]RegisterUserBindingModel model
       )
        {
            // get the user to verifty
            var userToVerify = _userManager.FindByNameAsync(model.UserName);
            if (userToVerify.Result != null) { throw new Exception(AlreadyexistUser); }

            App.DataAccess.Identity.AspNetUsers user = new App.DataAccess.Identity.AspNetUsers
            {
                FirstName = "Ali",
                UserName = "Ali12345"
            };
           //// App.DataAccess.Identity.AspNetUsers userIdentity = _mapper.Map<App.DataAccess.Identity.AspNetUsers>(model);
            IdentityResult result = _userManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded == false) { throw new Exception(AlreadyexistUserName); }
            var rModel = new SuccessViewModel
            {
                Detail = RegisterSuccessDetail
            };
            return Success(rModel);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginAppViewModel), Constants.Http200)]
        public async Task<IActionResult> Login([FromBody]CredentialsBindingModel credentials
       )
        {
                if (!ModelState.IsValid) { throw new Exception(); }

                ClaimsIdentity identity = GetClaimsIdentity(credentials.UserName, credentials.Password).Result;
                if (identity == null) { throw new Exception("Please enter valid credentials"); }

                JwtTokenViewModel jwt = Tokens.GenerateJwt(identity, _jwtFactory, _jwtOptions).Result;
            //    var refreshToken = await _userService.GetRefreshToken(jwt.Id);
            //    jwt.RefreshToken = refreshToken.Token;
            LoginAppViewModel model = new LoginAppViewModel
            {
               // Content = jwt
            };
            return Success(model);
        }


        #endregion


        #region |Helper|

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByEmailAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            var checkPassword = await _userManager.CheckPasswordAsync(userToVerify, password);
            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, Convert.ToString(userToVerify.Id)));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentityForRefreshToken(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByEmailAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, Convert.ToString(userToVerify.Id)));


        }

        #endregion
    }
}