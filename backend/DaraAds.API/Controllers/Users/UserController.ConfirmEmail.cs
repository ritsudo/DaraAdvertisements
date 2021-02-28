﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DaraAds.API.Controllers.Users
{
    public partial class UserController :ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var isSuccessful = await _identityService.ConfirmEmail(userId, token);
            if(isSuccessful)
            {
                return Ok("Почта подтверждена");
            }

            return BadRequest("Неправильный токе или индификатор пользователя");
        }
    }
}
