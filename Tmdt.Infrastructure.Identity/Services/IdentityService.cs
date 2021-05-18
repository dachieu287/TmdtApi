using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tmdt.Domain.Enums;
using Tmdt.Infrastructure.Identity.Entities;
using Tmdt.Infrastructure.Identity.Interfaces;
using Tmdt.Infrastructure.Identity.Request;
using Tmdt.Infrastructure.Identity.Responses;

namespace Tmdt.Infrastructure.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public IdentityService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<BaseResponse> ChangePassword(ChangePasswordRequest request, ClaimsPrincipal claims)
        {
            var user = await _userManager.GetUserAsync(claims);

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

            if (result.Succeeded)
            {
                return new BaseResponse
                {
                    Succeeded = true,
                    Message = "Đổi mật khẩu thành công"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Succeeded = false,
                    Message = "Đổi mật khẩu thất bại, mật khẩu hiện tại không chính xác"
                };
            }
        }

        public async Task<bool> CheckUsernameExists(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<UserResponse> GetProfile(ClaimsPrincipal claims)
        {
            var user = await _userManager.GetUserAsync(claims);
            var response = new UserResponse
            {
                Username = user.UserName,
                Name = user.FullName,
                Email = user.Email,
                Phone = user.PhoneNumber
            };
            return response;
        }

        public async Task<UserResponse> GetProfileById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var response = new UserResponse
            {
                Username = user.UserName,
                Name = user.FullName,
                Email = user.Email,
                Phone = user.PhoneNumber
            };
            return response;
        }

        public string GetUserId(ClaimsPrincipal claims)
        {
            string id = _userManager.GetUserId(claims);
            return id;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var userRole in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTSettings:Key"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWTSettings:Issuer"],
                    audience: _configuration["JWTSettings:Audience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                var userResponse = new UserResponse
                {
                    Name = user.FullName,
                    Username = user.UserName,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Roles = userRoles
                };

                return new LoginResponse
                {
                    Succeeded = true,
                    User = userResponse,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            else
            {
                return new LoginResponse
                {
                    Succeeded = false
                };
            }
        }

        public async Task<BaseResponse> Logup(LogupRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user != null)
            {
                return new BaseResponse
                {
                    Succeeded = false,
                    Message = "Tên tài khoản đã tồn tại"
                };
            }

            user = new User
            {
                UserName = request.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = request.Email,
                PhoneNumber = request.Phone,
                FullName = request.Name
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return new BaseResponse
                {
                    Succeeded = false,
                    Message = "Mật khẩu không hợp lệ"
                };
            }

            await _userManager.AddToRoleAsync(user, Roles.User);
            return new BaseResponse
            {
                Succeeded = true,
                Message = "Tạo tài khoản thành công"
            };
        }

        public async Task<BaseResponse> UpdateProfile(UpdateProfileRequest request, ClaimsPrincipal claims)
        {
            var user = await _userManager.GetUserAsync(claims);
            user.FullName = request.Name;
            user.Email = request.Email;
            user.PhoneNumber = request.Phone;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new BaseResponse
                {
                    Succeeded = true,
                    Message = "Cập nhật thành công"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Succeeded = false,
                    Message = result.Errors.ToString()
                };
            }
        }
    }
}
