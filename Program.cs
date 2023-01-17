using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HRapp.Data;
using HRapp.Pages.Models;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<HRappContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HRappContext") ?? throw new InvalidOperationException("Connection string 'HRappContext' not found.")));


var app = builder.Build();
app.UseDeveloperExceptionPage();
using (var scope = app.Services.CreateScope())
{

}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
