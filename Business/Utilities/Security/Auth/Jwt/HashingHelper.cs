using System.Text;
using Business.Utilities.Security.Auth.Jwt.Interface;

namespace Business.Utilities.Security.Auth.Jwt;

// Şifre oluşturma ve doğrulama işlemleri için yardımcı sınıf
public class HashingHelper : IHashingHelper
{
    // Verilen şifreyi kullanarak, rastgele bir tuz (salt) ve hash oluşturur
    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        // HMACSHA512 algoritmasını kullanarak bir şifreleme anahtarı oluşturur
        using (var hmac = new System.Security.Cryptography.HMACSHA512())
        {
            // Anahtarın kendisini tuz olarak kullanır
            passwordSalt = hmac.Key;

            // Verilen şifreyi UTF-8 formatında byte dizisine çevirip hashler
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    // Verilen şifrenin doğruluğunu kontrol eder
    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        // HMACSHA512 algoritmasını kullanarak bir şifreleme anahtarı oluşturur
        using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        {
            // Verilen şifreyi UTF-8 formatında byte dizisine çevirip hashler
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Hesaplanan hash'in uzunluğu, kayıtlı hash'in uzunluğuna eşit değilse hemen false döndür
            if (computedHash.Length != passwordHash.Length)
            {
                return false;
            }

            // Hesaplanan hash ile kayıtlı hash'in her bir byte'ını karşılaştırır
            // Eğer herhangi bir byte farklı ise hemen false döndür
            for (var i = 0; i < computedHash.Length; ++i)
            {
                if (computedHash[i] != passwordHash[i])
                {
                    return false;
                }
            }
        }

        // Yukarıdaki koşulların hiçbiri sağlanmazsa, şifre doğrudur ve true döndürülür
        return true;
    }
}
