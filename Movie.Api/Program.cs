using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Movie.Infra.Persistence.Contexts;
using Movie.Infra.Persistence.Seeds;
using Movie.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.SolveDependenciesInstance();
builder.Services.AddTransient<Seeds>();
// allow all cors origins
builder.Services.AddCors();
// use cors
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API teste", Version = "v12" }); });

// add token
builder.Services.AddAuthentication(x => { x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; })
    .AddJwtBearer("Bearer", options =>
    {
        // options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("12345678901234567890123456789012")),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });
var app = builder.Build();
if (args.Length == 1 && args[0].ToLower() == "seeddata") SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var scopedServices = scope.ServiceProvider;
        var db = scopedServices.GetRequiredService<PopCornContext>();
        var seed = scopedServices.GetRequiredService<Seeds>();
        seed.Seed();
    }
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyOrigin();
    c.AllowAnyMethod();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
