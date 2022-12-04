using GlobalRank;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var startup = new Startup(builder.Configuration);

var app = builder.Build();

startup.Configure(app, app.Environment);