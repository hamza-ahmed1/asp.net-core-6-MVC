var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//builten middlewares
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.Run(async (context) => { await context.Response.WriteAsync("My first middleware"); });
//app.Run(async (context) => { await context.Response.WriteAsync("ANother text"); }) ;
// In run we 
app.Use(async (context,next) => {
    await context.Response.WriteAsync("My first middleware\n");
    await next(context);
});
app.Run(async (context) => {
    await context.Response.WriteAsync("Another text");
   
});
app.Run();
