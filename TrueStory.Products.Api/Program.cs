using FluentValidation.AspNetCore;
using FluentValidation;
using Serilog;
using TrueStory.Products.RestfulApi;
using TrueStory.Products.Core.Validators;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRestfulApi(builder.Configuration);
builder.Services.AddProductService();
builder.Host.UseSerilog();

builder.Services.AddValidatorsFromAssemblyContaining<AddProductRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();

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
