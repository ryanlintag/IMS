using BlazorWebApp7;
using Domain;
using Application;
using Presentation;
using Infrastructure;
using Persistance;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Carter;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.Sources.Clear();
//builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddTelerikBlazor();

builder.Services.AddDomain()
                .AddApplication()
                .AddPresentation()
                .AddInfrastructure()
                .AddPersistance();

builder.Services.RegisterHttpClientServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapCarter();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
