using Infra.EntityFrameworkCore;
using Infra.EntityFrameworkCore.Repository;

//private readonly IConfiguration _configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();

//builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(x =>
                                          x.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
