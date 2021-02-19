﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DaraAds.Application.Services.User.Interfaces;
using System.Threading;
using DaraAds.Application.Services.User.Contracts;
using System.Net;

namespace DaraAds.API.Controllers.Users
{
    public partial class UserController : ControllerBase
    {
        [HttpPost("login")]
        [ProducesResponseType(typeof(Login.Response), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Login(
            [FromBody] UserLoginRequest request,
            [FromServices] IUserService service,
            CancellationToken cancellationToken)
        {
            return Ok(await service.Login(new Login.Request
            {
                Email = request.Email,
                Password = request.Password
            }, cancellationToken)); ;
        }
    }
    
    public sealed class UserLoginRequest {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}