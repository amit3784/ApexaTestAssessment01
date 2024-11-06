using ApexaTechAssess.Api.ExternalSystems;
using ApexaTechAssess.Api.Features.AdvisorFeatures.DB;
using ApexaTechAssess.Api.Features.AdvisorFeatures.Repos;
using Carter;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAdvisorRepository, AdvisorRepository>();
builder.Services.AddDbContext<AdvisorDbContext>(options => {
    options.UseInMemoryDatabase("ApexaAssessmentDB");
});
builder.Services.AddCarter();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
var app = builder.Build();

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
