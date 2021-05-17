using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tmdt.Infrastructure.Identity.Entities;
using Tmdt.Infrastructure.Identity.Request;
using Tmdt.Infrastructure.Identity.Responses;

namespace Tmdt.Infrastructure.Identity.Interfaces
{
    public interface IIdentityService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<UserResponse> GetProfile(ClaimsPrincipal claims);
        Task<BaseResponse> ChangePassword(ChangePasswordRequest request, ClaimsPrincipal claims);
        Task<BaseResponse> UpdateProfile(UpdateProfileRequest request, ClaimsPrincipal claims);
        Task<BaseResponse> Logup(LogupRequest request);
        Task<bool> CheckUsernameExists(string username);
        string GetUserId(ClaimsPrincipal claims);
    }
}
