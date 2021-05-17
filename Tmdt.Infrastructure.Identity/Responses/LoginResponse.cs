namespace Tmdt.Infrastructure.Identity.Responses
{
    public class LoginResponse : BaseResponse
    {
        public UserResponse User { get; set; }
        public string Token { get; set; }
    }
}
