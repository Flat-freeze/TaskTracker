using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Data;
using TaskTracker.Models;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString( "DefaultConnection" );
builder.Services.AddDbContext<ApplicationDbContext>( options => options.UseNpgsql( connectionString ) );
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>( options =>
													 {
														 options.SignIn.RequireConfirmedAccount  = false;
														 options.Password.RequireNonAlphanumeric = false;
													 }
													)
	   .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentityServer().AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

builder.Services.AddAuthentication().AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if( app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "v1");
		c.RoutePrefix = String.Empty;
	});
}
//else
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	//app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute( "default", "{controller}/{action=Index}/{id?}" );
app.MapRazorPages();

app.MapFallbackToFile( "index.html" );

app.Run();