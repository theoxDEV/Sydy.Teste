using SydyTeste.Data.DB;
using SydyTeste.Data.Models.Helpers;
using SydyTeste.Data.Services;
using SydyTeste.Data.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<SqlConnectSettings>(builder.Configuration.GetSection("SqlConnectSettings"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITeamsService, TeamsService>();
builder.Services.AddScoped<ICupService, CupService>();

builder.Services.AddDbContext<SydyDataContext>();

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
