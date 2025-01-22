using dotenv.net;
using VmMaster.Interfaces;
using VmMaster.Services;
using VmMaster.Utils;

var builder = WebApplication.CreateBuilder(args);
DotEnv.Load();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ServiceFactory<ICloudService>>();
builder.Services.AddScoped<ICloudService, AwsService>();
builder.Services.AddScoped<ICloudService, DigitalOceanService>();
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


