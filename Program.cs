using System.Reflection;
using api_auction.Data.Opportunity;
using api_auction.Models;
using dotenv.net;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using Newtonsoft;

var builder = WebApplication.CreateBuilder(args);

string sAllowSpecificOrigins = "_sAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Test Front-end JR",
        Description = "Esta API fornecerá os dados necessários para o teste de front end. Dúvidas podem enviar um e-mail para italo.cassio@brasil317.com.br",     
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<JaspionDbContext>();

builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: sAllowSpecificOrigins,
                                builder =>
                                {
                                    builder
                                    .WithOrigins(
                                                    "http://localhost:3000",
                                                    "http://localhost:*"
                                                )
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials()
                                    .SetIsOriginAllowedToAllowWildcardSubdomains();
                                });
            });

builder.Services.AddScoped(typeof(IOpportunityRepository), typeof(OpportunityRepository));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    DotEnv.Config();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(sAllowSpecificOrigins);

app.Run();
