﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DaraAds.Application.Services.User.Interfaces;
using System.Threading;
using DaraAds.Application.Services.User.Contracts;
using DaraAds.Application.Identity.Interfaces;

namespace DaraAds.API.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IIdentityService _identityService;

        public UserController(IUserService userService, IIdentityService identityService)
        {
            _userService = userService;
            _identityService = identityService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register(
            [FromBody] UserRegisterRequest request,
            CancellationToken cancellationToken)
        {
            var registrationResult = await _userService.Register(new Register.Request
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Password = request.Password
            }, cancellationToken);

            return Created($"api/v1/users/{registrationResult.UserId}", new { });
        }        
    }
    
    public sealed class UserRegisterRequest
    {
        [Required(ErrorMessage = "Имя пользователя - обязательно")]
        public string Name { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "Email пользователя - обязательно")]
        public string Email { get; set; }

        public string Phone { get; set; }

        [MaxLength(30)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
