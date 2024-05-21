using ASD.Commerce.Application;
using ASD.Commerce.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("CommerceContext");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer( connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

ServiceDependencies.Configure(builder.Services);
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAnyOrigin",
        policyBldr => policyBldr.AllowAnyOrigin().AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAnyOrigin");

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
