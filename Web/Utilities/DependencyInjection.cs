using Business.Services;
using Business.Services.Interface;
using Business.Utilities.Security.Auth.Jwt;
using Business.Utilities.Security.Auth.Jwt.Interface;
using Business.Utilities.Validation;
using Business.Utilities.Validation.Interface;
using Core.Utilities.Mail;
using Infrastructure.Data.Postgres;
using Infrastructure.Data.Postgres.Repositories;
using Infrastructure.Data.Postgres.Repositories.Interface;

namespace Web.Utilities;

// Bağımlılık enjeksiyonu işlemlerini düzenleyen yardımcı sınıf
public static class DependencyInjection
{
    // Scoped servisler, her istemci için tek bir kopya olacak şekilde kaynakları paylaşır.
    public static void AddMyScoped(this IServiceCollection serviceCollection)
    {
        // Veritabanı işlemleri için UnitOfWork
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        // JWT token taleplerine erişim sağlayan yardımcı sınıf
        serviceCollection.AddScoped<IClaimHelper, ClaimHelper>();

        // Kullanıcı kimlik doğrulama işlemlerini yürüten servis sınıfı
        serviceCollection.AddScoped<IAuthService, AuthService>();

        // İş modelleriyle ilgili işlemleri gerçekleştiren servis sınıfları
        serviceCollection.AddScoped<IProjectService, ProjectService>();
        serviceCollection.AddScoped<IRoomService, RoomService>();
        serviceCollection.AddScoped<IMyTaskService, MyTaskService>();
        serviceCollection.AddScoped<ITicketService, TicketService>();
        serviceCollection.AddScoped<IUserService, UserService>();
    }

    // Singleton servisler, uygulama başına yalnızca bir kopyaya sahip olacak şekilde kaynakları paylaşır.
    public static void AddMySingleton(this IServiceCollection serviceCollection)
    {
        // HttpContext'ten talepleri almak için IHttpContextAccessor
        serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        // Nesne eşleme işlemlerini gerçekleştiren yardımcı sınıf
        serviceCollection.AddSingleton<IMapperHelper, MapperHelper>();

        // Doğrulama işlemlerini gerçekleştiren yardımcı sınıf
        serviceCollection.AddSingleton<IValidationHelper, ValidationHelper>();

        // JWT token oluşturma işlemlerini yürüten yardımcı sınıf
        serviceCollection.AddSingleton<IJwtTokenHelper, JwtTokenHelper>();

        // Şifreleme ve şifre kontrol işlemlerini yürüten yardımcı sınıf
        serviceCollection.AddSingleton<IHashingHelper, HashingHelper>();

        // E-posta gönderme işlemlerini gerçekleştiren yardımcı sınıf
        serviceCollection.AddSingleton<IMailHelper, MailHelper>();
    }

    // Transient servisler, her çağrı için yeni bir kopya oluşturur ve kaynakları paylaşmaz.
    public static void AddMyTransient(this IServiceCollection serviceCollection)
    {
        // Herhangi bir transient servis eklemek için gerekirse buraya ekleyebilirsiniz.
    }
}
