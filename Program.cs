using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QuadraticEquation.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuadraticEquation API", Version = "v1" });
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Ép xuất file cấu hình theo chuẩn Swagger 2.0 để giao diện web đọc được 100%
app.UseSwagger(c =>
{
    c.SerializeAsV2 = true;
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "QuadraticEquation v1");
});

app.UseAuthorization();
app.MapControllers();

app.Run();