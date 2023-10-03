using Infrastructure.Data.Postgres.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Text;
using Web.Utilities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Kültür ayarlarını Türkçe olarak ayarla
var cultureInfo = new CultureInfo("tr-Tr");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// CORS (Cross-Origin Resource Sharing) politikasını tanımla
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", cBuilder =>
{
    cBuilder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed(_ => true)
        .AllowCredentials();
}));

// PostgreSQL veritabanı bağlantı dizesini al
var postgresConnectionString = builder.Configuration.GetConnectionString("PsqlConnection");

// PostgreSQL veritabanı bağlantısını eklemek için DbContext'ini yapılandır
builder.Services.AddDbContext<PostgresContext>(dbContextOptionsBuilder =>
    dbContextOptionsBuilder.UseNpgsql(postgresConnectionString, npgsqlDbContextOptionsBuilder =>
        npgsqlDbContextOptionsBuilder.MigrationsAssembly("Web")));

// Uygulama servislerini ekleyin
builder.Services.AddMySingleton();
builder.Services.AddMyScoped();
builder.Services.AddMyTransient();

// Controller'ları ekleyin
builder.Services.AddControllers();

// Swagger/OpenAPI belgelendirmesini ekleyin
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "PortalBackend",
        Description = ".NET 7 / ASP.NET Core Web API",
    });
});

// JWT (Json Web Token) doğrulama ekleyin
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtBearerOptions =>
{
    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
        ValidAudience = builder.Configuration["TokenOptions:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenOptions:SecurityKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// HTTP isteği pipeline'ını yapılandır
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS politikasını etkinleştir
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

// Yetkilendirme kullan
app.UseAuthorization();

// Controller'ları eşleştir
app.MapControllers();

// Uygulamayı çalıştır
app.Run();

