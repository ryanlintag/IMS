using BlazorApp8.Components;
using Domain;
using Application;
using Presentation;
using Infrastructure;
using Persistance;
using BlazorApp8;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Persistance.DbContexts;
using Domain.Users;
using Domain.ValueObjects;
using Domain.Users.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDomain()
                .AddApplication()
                .AddPresentation()
                .AddInfrastructure()
                .AddPersistance();

builder.Services.RegisterHttpClientServices(builder.Configuration);

builder.BuildPresentationHost();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UsePresentation();
DbInitialize.Initialize(app);

app.Run();
