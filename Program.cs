using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Capstone_Connect.Data;
using Microsoft.AspNetCore.Authentication;
using Capstone_Connect.Handler;
using Microsoft.AspNetCore.Authentication.OAuth;
using Capstone_Connect.Helper;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CapstoneConnectDBContext>(options => options.UseSqlite(builder.Configuration["Capstone_ConnectConnection"]));
builder.Services.AddScoped<ICapstoneConnectRepo, DBCapstoneConnectRepo>();
builder.Services.AddAuthentication()
.AddScheme<AuthenticationSchemeOptions, AuthHandler>
("AuthenticationScheme", null).
Services.AddAuthorization(options =>
{
    options.AddPolicy("VisitorOnly", policy => policy.RequireClaim("visitor"));
    options.AddPolicy("UserOnly", policy => policy.RequireClaim("user"));
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim("admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseAuthorization();
app.MapControllers();

app.Run();
