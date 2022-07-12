using ExaminationSystem.Reprository;
using ExaminationSystemProject.Models;
using ExaminationSystemProject.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IQuestion, QuestionRepository>();
builder.Services.AddDbContext<Context>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer(@"Data source =DESKTOP-JT45RDG;Initial Catalog =myExamination; Integrated security=true");
});

builder.Services.AddScoped<ICourseReprository, CourseReprository>();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
