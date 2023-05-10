
using Microsoft.EntityFrameworkCore;
using rfidProject.Data;
using Microsoft.AspNetCore.Identity;
using rfidProject.Models;
using rfidProject.Core.IRepositories;
using rfidProject.Repositories;
using rfidProject.Core;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'rfidProjectContextConnection' not found.");

builder.Services.AddDbContext<rfidProjectContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<rfidProjectContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Authorization

AddAuthorizationPolicies();
AddScoped();

#endregion




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

void AddAuthorizationPolicies()
{
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy(Constants.Policies.RequireAdmin, policy => policy.RequireRole(Constants.Roles.Administrator));
        options.AddPolicy(Constants.Policies.RequireProducer, policy => policy.RequireRole(Constants.Roles.Producer));
        options.AddPolicy(Constants.Policies.RequireSlaughterHouse, policy => policy.RequireRole(Constants.Roles.SlaughterHouse));
    });


}


void AddScoped()
{
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<ISlaughterRepository, SlaughterRepository>();
    builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    builder.Services.AddScoped<IRfidRepository, RfidRepository>();
    builder.Services.AddScoped<ICattleRepository, CattleRepository>();
    builder.Services.AddScoped<ICattleSlaughtered, CattleSlaughtered>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
}
