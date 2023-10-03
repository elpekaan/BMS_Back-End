using Business.Models.Request.Functional;
using Business.Models.Response;
using Business.Services.Interface;
using Business.Utilities.Security.Auth.Jwt;
using Core.Results;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;
using Web.Filters;

// Kullanıcı kimlik doğrulama ve yetkilendirme işlemlerini gerçekleştiren kontrolör sınıfı
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // Kullanıcı girişi için HTTP Post metodu
    [HttpPost]
    public async Task<ActionResult<DataResult<Token>>> Login([FromBody] LoginDto loginDto)
        => await _authService.Login(loginDto);

    // Kullanıcı kaydı için HTTP Post metodu
    [HttpPost]
    public async Task<ActionResult<DataResult<Token>>> Register([FromBody] RegisterDto registerDto)
        => await _authService.Register(registerDto);

    // Kullanıcının profil bilgilerini getiren HTTP Get metodu
    [HttpGet]
    [Authorize] // Yetkilendirme filtresi kullanılarak sadece yetkilendirilmiş kullanıcıların erişimine izin verilir
    public async Task<ActionResult<DataResult<UserProfileDto>>> GetProfileInfo()
        => await _authService.GetUserProfileInfo();

    // Token yenileme işlemi için HTTP Get metodu
    [HttpGet]
    public async Task<ActionResult<DataResult<Token>>> RefreshToken(string token)
        => await _authService.RefreshToken(token);
}
