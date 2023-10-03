using Business.Models.Request.Functional;
using FluentValidation;

namespace Business.Utilities.Validation
{
    // RegisterDto tipi için doğrulama kurallarını içeren sınıf
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public RegisterValidator()
        {
            // E-Mail boş olmamalı ve minimum uzunluğu 8 karakter olmalı
            RuleFor(x => x.Email).NotEmpty().WithName("E-Mail").MinimumLength(8);

            // Kullanıcı adı boş olmamalı ve minimum uzunluğu 5 karakter olmalı
            RuleFor(x => x.UserName).NotEmpty().WithName("Kullanıcı Adı").MinimumLength(5);

            // Şifre boş olmamalı ve minimum uzunluğu 8 karakter olmalı
            RuleFor(x => x.Password).NotEmpty().WithName("Şifre").MinimumLength(8);
        }
    }
}
