using Microsoft.EntityFrameworkCore;
using CarRentalAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// ���������� ����������� � ���� ������
builder.Services.AddDbContext<CarRentalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ���������� Swagger/OpenAPI ������������
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ���������� ������������
builder.Services.AddControllers();

var app = builder.Build();

// ��������� HTTP ��������
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();