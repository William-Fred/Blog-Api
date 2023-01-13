using BlogProjectAPI.Models;
using BlogProjectAPI.Models.Auth;
using BlogProjectAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJwtService _jwtService;

        public UsersController(
            UserManager<IdentityUser> userManager,
            IJwtService jwtService,)
        {
            this._userManager = userManager;
            this._jwtService = jwtService;
        }
        // GET: api/Users/username
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            IdentityUser user = await _userManager.FindByNameAsync(username);

            if(user == null)
            {
                return NotFound();
            }

            return new User
            {
                UserName = user.UserName,
                Email = user.Email
            };
        }
        // POST: api/Users/BearerToken
        [HttpPost("BearerToken")]
        public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(AuthenticationRequest authRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad Credentials");
            }
            var user = await _userManager.FindByNameAsync(authRequest.UserName);

            if(user == null)
            {
                return BadRequest("Bad Credentials");
            }

            var isPasswrodValid = await _userManager.CheckPasswordAsync(user, authRequest.Password);
            if (!isPasswrodValid)
            {
                return BadRequest("Bad Credentials");
            }

            var token = _jwtService.CreateToken(user);

            return Ok(token);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userManager.CreateAsync(new IdentityUser()
            {
                UserName = user.UserName,
                Email = user.Email,

            }, user.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            user.Password = null;
            return Created("", user);
        }
    }
}
