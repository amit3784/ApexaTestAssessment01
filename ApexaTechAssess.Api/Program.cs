using ApexaTechAssess.Api.ExternalSystems;
using ApexaTechAssess.Api.Features.AdvisorFeatures.DB;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using Carter;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                      });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Version = "v1",
        Description = "API to create, read,update and delete advisor information from in-memory database",
        Title = "Advisor API"
    });
});

builder.Services.AddTransient<IAdvisorRepository, AdvisorRepository>();
builder.Services.AddScoped<CustomExceptionLogger>();
builder.Services.AddDbContext<AdvisorDbContext>(options => {
    options.UseInMemoryDatabase("ApexaAssessmentDB");
});

builder.Services.AddCarter();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<CustomExceptionLogger>();
app.MapCarter();
app.Run();
