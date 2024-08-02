using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using N_Health_API.Repositories.Master;
using N_Health_API.Repositories.Shared;
using N_Health_API.RepositoriesInterface.Master;
using N_Health_API.RepositoriesInterface.Shared;
using N_Health_API.Services;
using N_Health_API.Services.Master;
using N_Health_API.ServicesInterfece.Master;
using N_Health_API.ServicesInterfece.Shared;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var _secretKey = Encoding.ASCII.GetBytes("SecretkeyOfLogisboy&N-Health2024");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "N- Health API",
        Description = "Backend API of N- Health System",
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                new List<string>()
            }
        });
});

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,         // Validate the server that generates the token
            ValidateAudience = false,       // Validate the recipient of the token
            ValidateLifetime = true,      // Validate token expiration
            ValidateIssuerSigningKey = true, // Validate the signature key
            IssuerSigningKey = new SymmetricSecurityKey(_secretKey) // Set your secret key
        };
    });

#region Services
builder.Services.AddTransient<IPermissionService, PermissionService>();
builder.Services.AddTransient<IAccessTokenService,AccessTokenService>();
builder.Services.AddTransient<IUserinfoService, UserinfoService>();
#endregion
#region data 
builder.Services.AddTransient<IPermissionData, PermissionData>();
builder.Services.AddTransient<IAuthenRepository, AuthenRepository>();
builder.Services.AddTransient<IUserinfoData, UserinfoData>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
