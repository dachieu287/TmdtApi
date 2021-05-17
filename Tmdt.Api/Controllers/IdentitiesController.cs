using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tmdt.Infrastructure.Identity.Interfaces;
using Tmdt.Infrastructure.Identity.Request;
using Tmdt.Infrastructure.Identity.Responses;

namespace Tmdt.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentitiesController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentitiesController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _identityService.Login(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Logup([FromBody] LogupRequest request)
        {
            var resposne = await _identityService.Logup(request);
            return Ok(resposne);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var response = await _identityService.GetProfile(User);
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var response = await _identityService.ChangePassword(request, User);
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileRequest request)
        {
            var response = await _identityService.UpdateProfile(request, User);
            return Ok(response);
        }

        [HttpGet]
        public async Task<bool> CheckUsernameExists(string username)
        {
            return await _identityService.CheckUsernameExists(username);
        }
    }
}
