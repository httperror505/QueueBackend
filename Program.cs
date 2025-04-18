using Backend;
using Backend.Hub;
using Backend.Repository.Department;
using Backend.Repository.RDepartment;
using Backend.Repository.RTicket;
using Backend.Repository.RTicketDocument;
using Backend.Service.SDerpartment;
using Backend.Service.STicket;
using Backend.Service.STicketDocument;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configure the HTTP request pipeline.
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ITicketFinanceRepository, TicketFinanceRepository>();
builder.Services.AddScoped<ITicketFinanceService, TicketFinanceService>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<QueueDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();
app.UseCors("AllowAll");  // ✅ Enable CORS

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

// Always map Scalar API, even in production
app.MapScalarApiReference();
app.MapOpenApi();

app.UseWebSockets();  // ✅ Enable WebSockets

app.UseHttpsRedirection();
app.MapControllers();
app.MapHub<OnlineAccountHub>("/onlineaccounts-hub");
app.MapHub<ActiveCounterHub>("/activecounter-hub");

app.MapGet("/", () => "Backend API is running!");

//app.Run();
app.Run();
