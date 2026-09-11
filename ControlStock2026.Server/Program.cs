using ControlStock.BD.Datos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Servicios
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
     // throw new InvalidCastException("Connection string 'DefaultConnection'");

builder.Services.AddDbContext<AppDbContext>
    (options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();
void GetConnectionString(string v)
{
    throw new NotImplementedException();
}
#endregion


var app = builder.Build();

#region Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

#endregion

app.Run();
