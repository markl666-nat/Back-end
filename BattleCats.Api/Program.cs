using BattleCats.BusinessLogic.Structure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Connection string из appsettings.json подаЄм в DbSession (используетс€ во всех DbContext'ах)
BattleCats.DataAccess.DbSession.ConnectionStrings =
    builder.Configuration.GetConnectionString("DefaultConnection")!;
// CORS Ч разрешаем фронту с локального dev-сервера обращатьс€ к API.
// –егистраци€ политики (addPolicy). јктиваци€ ниже через app.UseCors("AllowFrontend").
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",   // Vite dev по умолчанию
                "http://localhost:5174",   // запасной порт Vite
                "http://localhost:3000"    // на случай если переключат на CRA
              )
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger с поддержкой кнопки "Authorize" Ч туда вводитс€ JWT, и все защищЄнные
// эндпоинты будут отправл€ть header "Authorization: Bearer <token>" автоматически
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "¬ведите JWT-токен, полученный по /api/session/auth"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// –егистрируем JWT Bearer authentication.
// ѕараметры валидации свер€ютс€ с тем что мы кладЄм в TokenService при выпуске токена.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JwtSettings.Issuer,
            ValidAudience = JwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(JwtSettings.SecretKey)),
            NameClaimType = ClaimTypes.Name,
            RoleClaimType = ClaimTypes.Role   // ? важно: даЄт работать [Authorize(Roles="...")]
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();   // отключено дл€ dev Ч фронт ходит по HTTP с Vite
app.UseCors("AllowFrontend");

//  –»“»„Ќќ: пор€док middleware Ч Authentication ƒќ Authorization.
// Authentication читает токен и заполн€ет HttpContext.User.
// Authorization потом провер€ет [Authorize] и роли.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();