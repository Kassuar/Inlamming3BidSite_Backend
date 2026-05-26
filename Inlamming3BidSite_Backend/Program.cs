
using Inlamming3BidSite_Backend.Core.Interfaces;
using Inlamming3BidSite_Backend.Core.Services;
using Inlamming3BidSite_Backend.Data;
using Inlamming3BidSite_Backend.Data.Interfaces;
using Inlamming3BidSite_Backend.Data.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "http://localhost:5021",
        ValidAudience = "http://localhost:5021",
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("mykey1234567&%%485734579453%&//1255362"))
    };
});

//Dependency Injection
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAuctionRepo, AuctionRepo>();
builder.Services.AddScoped<IBidRepo, BidRepo>();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IBidService, BidService>();
builder.Services.AddScoped<IUserService, UserService>();
 

var app = builder.Build();


app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 400;
        context.Response.ContentType =
            "application/json";

        var feature = context.Features
            .Get<IExceptionHandlerFeature>();

        if (feature != null)
        {
            await context.Response
                .WriteAsJsonAsync(
                new
                {
                    Message =
                    feature.Error.Message
                });
        }
    });
});


// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Routing
app.UseRouting();

// Auth
app.UseAuthentication();
app.UseAuthorization();

// CORS
app.UseCors(options =>
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

// Controllers

app.MapControllers();

app.Run();
