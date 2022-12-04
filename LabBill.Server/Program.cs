using LabBill.Server.Data;
using LabBill.Server.Service.AssetService;
using LabBill.Server.Service.BillService;
using LabBill.Server.Service.HelperService;
using LabBill.Server.Service.PersonService;
using LabBill.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IBillService, BillService>();
builder.Services.AddScoped<IHelperService, HelperService>();

builder.Services.AddControllers();
// builder.Services.AddControllers().AddJsonOptions(x =>
//     x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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