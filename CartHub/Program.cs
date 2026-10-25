using Microsoft.EntityFrameworkCore;
using CartHubData.DBContext;
using ICartHubService.ICartHubUserService;
using CartHubService.CarthubUserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding Cors
builder.Services.AddCors(options => {
    options.AddPolicy("ReactPolicy", policy => {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
}); 

//Add Connection String
builder.Services.AddDbContext<CartHubDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("StrCon")));
//Register Services
builder.Services.AddScoped<ICartHubUserService, CartHubUserService>();
var app = builder.Build();

app.UseCors("ReactPolicy");
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
