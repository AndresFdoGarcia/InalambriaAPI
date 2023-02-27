using InalambriaApi.Business.Core.Business.Domino;
using InalambriaApi.Business.Core.Service;
using InalambriaApi.Data.StringsC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var AutherConfiguration = new AutherManagerConfiguration(builder.Configuration.GetConnectionString("AutherConnetion"));
builder.Services.AddSingleton(AutherConfiguration);

builder.Services.AddScoped<AuthorizationService>();
builder.Services.AddScoped<DominoBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
