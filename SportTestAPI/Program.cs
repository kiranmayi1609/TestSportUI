
using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SportTestAPI.Database;
using SportTestAPI.DataModels;
using SportTestAPI.IGenericRepo;
using SportTestAPI.ImplementRepo;
using SportTestAPI.Mapping;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    //Define API documentationgroups 
    c.SwaggerDoc("SportsAPI", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Sports API", Version = "v1", Description = "APIs related to sports management" });
    c.SwaggerDoc("AuthAPI", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Authentication API", Version = "v2", Description = "APIs for user authentication " });


    
});

// Authentication & Authorization
builder.Services.AddAuthorization();

// Identity Configuration
builder.Services.AddIdentityCore<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();

// Database Configuration (Ensure the connection string is correct in appsettings.json)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SportData")));

//Identity Configuration 
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
//JWT Authentication Configuration 
// Configure JWT Authentication
// JWT Authentication
var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:ValidIssuer"],
            ValidAudience = builder.Configuration["JwtSettings:ValidAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

// Require email confirmation before login
builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
});

//Register UserService for dependency Injection 
builder.Services.AddScoped<IAuthService, AuthService>();
// Register EmailService
builder.Services.AddScoped<IEmailService,EmailService>();

// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Register Repositories
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IAgeGroupRepository, AgeGroupRepository>();
builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<ICourtRepository, CourtRepository>();
builder.Services.AddScoped<IInvoiceRepository,InvoiceRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<ITournmentRepository, TournmentRepository>();
builder.Services.AddScoped<ITrainingSessionRepository, TrainingSessionRepository>();
//builder.Services.AddScoped<ICoachRepository>
builder.Services.AddScoped(typeof(IGenericRepository<,,>), typeof(GenericRepo<,,>));

//builder.Services.AddScoped<BookingService>();


//Identity Configuration with cookie authentication 
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;

});
builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = true; // Ensure email confirmation is required
});


//Cookie based authentication 
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;//Secure cookies
    options.LoginPath = "/api/auth/login";//Redirect for Unauthorized access
    options.AccessDeniedPath = "/api/auth/accessdenied";//Redirect for access denied

});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI
    (c =>
    {
        // Define separate Swagger endpoints
        c.SwaggerEndpoint("/swagger/SportsAPI/swagger.json", "Sports API v1");
        c.SwaggerEndpoint("/swagger/AuthAPI/swagger.json", "Authentication API v1");
    });

}
app.UseStaticFiles();
// Middleware configuration
app.UseHttpsRedirection();
app.UseAuthentication(); // Missing in your code
app.UseAuthorization();
app.MapIdentityApi<ApplicationUser>();

app.MapControllers(); // Ensures controllers are mapped

app.Run();

