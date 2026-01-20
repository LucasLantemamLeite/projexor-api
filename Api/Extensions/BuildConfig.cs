using Api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static partial class Inject
{
    extension(WebApplicationBuilder builder)
    {
        public WebApplicationBuilder ApplyConfig()
        {
            var connectionString = builder.Configuration.GetConnectionString("Default");

            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

            return builder;
        }
    }
}