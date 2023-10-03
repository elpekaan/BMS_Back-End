using System.Threading.Tasks;

namespace Business.Utilities.Validation.Interface;

// Doğrulama yardımcı sınıfının arayüzü
public interface IValidationHelper
{
    // Asenkron olarak DTO'nun doğrulama işlemini gerçekleştiren metot
    Task<string> ValidateAsync(dynamic dto);
}
