using Eventify.Application.Abstractions.Services;
using Eventify.Persistence.Services;
using Eventify.Infrastructure.Services;
using Eventify.Persistence.DbContexts;
using Eventify.Application.Abstractions.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEventService, EventService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<ITextService, TextService>();
builder.Services.AddSingleton<EventifyDbContext>();
builder.Services.AddSingleton<ExportService>();





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
