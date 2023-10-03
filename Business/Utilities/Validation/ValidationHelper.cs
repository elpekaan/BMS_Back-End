using Business.Utilities.Validation.Interface;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Utilities.Validation
{
    // Farklı türlerdeki nesneleri doğrulamak için kullanılan sınıf
    public class ValidationHelper : IValidationHelper
    {
        private readonly List<IValidator> _validators;

        public ValidationHelper()
        {
            // LoginValidator ve RegisterValidator örnekleri ekleniyor
            _validators = new List<IValidator>
            {
                new LoginValidator(),
                new RegisterValidator(),
            };
        }

        // Nesneyi doğrular ve hata mesajını döndürür
        public async Task<string> ValidateAsync(object obj)
        {
            var error = "Cant Find Validator For The Object Type";

            // Doğrulayıcıyı bulma
            var validator = _validators.FirstOrDefault(v => v.CanValidateInstancesOfType(obj.GetType()));

            if (validator != null)
            {
                // Doğrulama bağlamını oluşturma
                var context = new ValidationContext<object>(obj);

                // Doğrulama işlemi
                var result = (ValidationResult)await validator.ValidateAsync(context);

                // Hata mesajını oluşturma
                error = string.Concat(result.Errors.Select(e => e.ErrorMessage.Replace("'", "") + " ")).Trim();
            }

            return error;
        }
    }
}
