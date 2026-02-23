using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using Scalar.AspNetCore;
using System.Text;
using TellADoc.API.Context;
using TellADoc.API.Seeder;
using TellADoc.API.Services;

namespace TellADoc.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var secret_key = builder.Configuration["JWT:key"]?.
                SelectMany(c => Encoding.UTF8.GetBytes(c.ToString())).ToArray() ?? new byte[0];
            var key = new SymmetricSecurityKey(secret_key);
            var issuer = builder.Configuration["JWT:issuer"];
            var audience = builder.Configuration["JWT:audience"];

            // Add services to the container.

            //builder.Services.
            builder.Services.AddSingleton<AuthService>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Register DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowClient", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            //builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        //IssuerSigningKey = new SymmetricSecurityKey("JANGAN_HARD_CODE_KEY_DI_CODING"u8.ToArray()),
                        IssuerSigningKey = key,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidateIssuer = true,
                        ValidateAudience = true
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                //app.MapScalarApiReference(options =>
                //{
                //    options.WithTitle("Dev API nih bosque");
                //});
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowClient");

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            //app.MapControllers().RequireAuthorization();

            //app.MapPost("/login", (LoginRequest request, TokenGenerator tokenGenerator) =>
            //{
            //    return new
            //    {
            //        token = tokenGenerator.GenerateToken(request.Email)
            //    };
            //});

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                DbSeeder.SeedDocuments(dbContext);
            }


            app.Run();
        }
    }
}
