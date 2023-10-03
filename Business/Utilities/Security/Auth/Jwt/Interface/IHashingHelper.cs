// Şifreleme (hashing) işlemleri için kullanılan arayüz
public interface IHashingHelper
{
    // Verilen bir şifreyi hash ve salt değerleri olarak oluşturur
    void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);

    // Verilen bir şifrenin, verilen hash ve salt değerleriyle eşleşip eşleşmediğini doğrular
    bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
}
