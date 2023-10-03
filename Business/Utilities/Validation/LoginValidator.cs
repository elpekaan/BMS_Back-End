using Business.Models.Request.Functional;
using FluentValidation;

namespace Business.Utilities.Validation
{
    // LoginDto tipi için doğrulama kurallarını içeren sınıf
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            // Kullanıcı adı boş olmamalı
            RuleFor(x => x.UserName).NotEmpty().WithName("Kullanıcı Adı");

            // Şifre boş olmamalı
            RuleFor(x => x.Password).NotEmpty().WithName("Şifre");
        }
    }
}
