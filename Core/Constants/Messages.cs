namespace Core.Constants;

public static class Messages
{
    // META
    public const string YouCantDoThat = "Bu işlemi yapamazsınız";
    public const string Success = "İşlem başarıyla tamamlandı";
    public const string NotFound = "Kayıt bulunamadı";
    public const string Error = "Hata alındı";

    // AUTH SERVICE
    public const string RefreshTokenNotValid = "Refresh Token Geçerli Değil";
    public const string EmailAlreadyTaken = "Bu Email Zaten Alınmış";
    public const string UserNameAlreadyTaken = "Bu Kullanıcı Adı Zaten Alınmış";
    public const string UserNameOrPasswordWrong = "Kullanıcı Adı veya Şifre Yanlış";

    // SUCCESS
    public const string SuccessfullyCreatedEntity = "Kayıt başarıyla oluşturuldu";
    public const string SuccessfullyUpdatedEntity = "Kayıt başarıyla güncellendi";
    public const string SuccessfullyDeletedEntity = "Kayıt başarıyla silindi";

    //FILE UPLOAD
    public const string InvalidFileFormat = "Geçersiz dosya türü";
}