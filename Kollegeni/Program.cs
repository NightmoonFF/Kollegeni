using Kollegeni.Data;
using Kollegeni.Interface;
using Kollegeni.Repositories;
using Kollegeni.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// EF Core med SQLite
//builder.Services.AddDbContext<BookingDbContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

//Test Database
//builder.Services.AddScoped<IBookingRepository, FakeBookingRep>();

// Repositories + services
builder.Services.AddScoped<IBookingRepository, FakeBookingRep>();
builder.Services.AddScoped<BookingService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Controllers
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();