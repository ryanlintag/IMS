using Domain;
using Application;
using Presentation;
using Infrastructure;
using Persistance;
using WebApi.Infrastructure;
using BlazorApp8;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddDomain()
                .AddApplication()
                .AddPresentation()
                .AddInfrastructure()
                .AddPersistance();


builder.BuildPresentationHost();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UsePresentation();
DbInitialize.Initialize(app);

app.Run();
