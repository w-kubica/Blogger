using AutoMapper;
using Blogger.Application.Interfaces;
using Blogger.Application.Mappings;
using Blogger.Application.Services;
using Blogger.Domain.Entities;
using Blogger.Domain.Interfaces;
using Blogger.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<IPostService, PostService>();

builder.Services.AddSingleton(AutoMapperConfig.Initialize());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});

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
