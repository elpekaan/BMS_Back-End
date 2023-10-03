namespace Business.Utilities.Security.Auth.Jwt;

// Token sınıfı, JWT ve yeniden token bilgilerini içerir
public class Token
{
    // Erişim token'ını temsil eden özellik
    public string AccessToken { get; set; }

    // Token'ın geçerlilik süresini temsil eden özellik
    public DateTime Expiration { get; set; }

    // Yeniden token'ı temsil eden özellik
    public string RefreshToken { get; set; }

    // Constructor ile sınıfın özelliklerini başlatan bir metot
    public Token(string accessToken, DateTime expiration, string refreshToken)
    {
        AccessToken = accessToken;
        Expiration = expiration;
        RefreshToken = refreshToken;
    }
}
