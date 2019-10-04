using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrdersAPI.Helpers;
using OrdersModel.Context;
using OrdersModel.Model;
using OrdersModel.Repositories.Interface;

namespace OrdersAPI.Controllers
{


    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private IRepositoryWrap _repositoryWrap;
        public AuthorizationController(IRepositoryWrap repositoryWrap)
        {
            _repositoryWrap = repositoryWrap;
        }

        #region Logger

        ILog logger = log4net.LogManager.GetLogger(typeof(AuthorizationController));

        #endregion

        /// <summary>
        ///  Login method
        /// </summary>
        /// <param name="request"></param>        
        /// <returns></returns>
        [HttpPost("token")]       
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]        
        [AllowAnonymous]
        public IActionResult Login(
           User request,
           [FromServices]SigningConfigurations signingConfigurations,
           [FromServices]TokenConfigurations tokenConfigurations)
        {

            try
            {

                if (request == null) {
                    logger.Error("request is null");
                    return BadRequest("User not found!");
                }

                if (string.IsNullOrEmpty(request.Username))
                {
                    logger.Error("Username is empty");
                    return BadRequest("User not found!");
                }
                var userRow = _repositoryWrap.User.FindByCondition(x => x.Username.Equals(request.Username)).FirstOrDefault();
                

                if (userRow == null)
                {
                    logger.Error("userRow is null");
                    return BadRequest("User not found!");
                }

                if (string.IsNullOrEmpty(request.Password)) {
                    logger.Error("Password is null");
                    return BadRequest("Invalid Password!");
                }


                if (!userRow.Password.Equals(request.Password, StringComparison.Ordinal)){
                    logger.Error("invalid Password ");
                    return BadRequest("Invalid Password!");
                }

                ClaimsIdentity identity = new ClaimsIdentity(
                   new GenericIdentity(userRow.Id.ToString(), "Login"),
                   new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userRow.Id.ToString())
                   }
               );
                DateTime dtCreation = DateTime.Now;
                DateTime dtExpires = dtCreation + TimeSpan.FromSeconds(tokenConfigurations.Seconds);
                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dtCreation,
                    Expires = dtExpires
                });
                var token = handler.WriteToken(securityToken);

                var returnValues = new { access_token = token, expires_in = tokenConfigurations.Seconds };

                return Ok(returnValues);

            
            }
            catch (Exception ex)
            {
                return BadRequest("Error :" + ex.Message);
                
            }
        }
    }
}