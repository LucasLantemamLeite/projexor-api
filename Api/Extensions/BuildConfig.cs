using System.Text;
using Api.Data.Context;
using Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Api.Extensions;

public static partial class Inject
{
    extension(WebApplicationBuilder builder)
    {
        public WebApplicationBuilder ApplyConfig()
        {
            TokenService.Key = builder.Configuration.GetValue<string>("JwtKey") ?? throw new NullReferenceException("Nenhuma JwtKey foi encontrada.");

            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenService.Key)),
                    RequireSignedTokens = true,
                    ValidTypes = ["JWT"],
                    ValidAlgorithms = [SecurityAlgorithms.HmacSha256Signature],
                    ValidateIssuer = true,
                    ValidIssuer = "ServerApi",
                    ValidateAudience = true,
                    ValidAudience = "ClientApi",
                    RequireAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5),
                    RequireExpirationTime = true,
                };
            });

            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
            }

            builder.Services.AddHealthChecks();

            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

            return builder;
        }
    }
}