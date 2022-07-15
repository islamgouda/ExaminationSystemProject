using ExaminationSystem.Reprository;
using ExaminationSystemProject.Models;
using ExaminationSystemProject.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC.Reposatories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IQuestion, QuestionRepository>();
builder.Services.AddScoped<IExam, ExamRespository>();
builder.Services.AddDbContext<Context>(optionsBuilder =>
{
    optionsBuilder.UseSqlServer("Data source =DESKTOP-RBFSHHC\\SQLEXPRESS;Initial Catalog =myExamination; Integrated security=true");
});

//Register usermanager,roleManager
 builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
     options=>options.Password.RequireDigit=true).
 AddEntityFrameworkStores<Context>();
    

   

   

//Custom Service
builder.Services.AddScoped<ICourseReprository, CourseReprository>();
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IExam, ExamRespository>();
builder.Services.AddScoped<IStudentExamRepository, StudentExamRepository>();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IInstructorReposatory, InstructorRepository>();

=======
>>>>>>> parent of 18053bb (Merge pull request #10 from A7MED-TAREK/master)
=======
>>>>>>> parent of 18053bb (Merge pull request #10 from A7MED-TAREK/master)
=======
>>>>>>> parent of 18053bb (Merge pull request #10 from A7MED-TAREK/master)
=======
builder.Services.AddScoped<IRegisterRepository, RegisterRepository>();
builder.Services.AddScoped<IInstructorReposatory, InstructorRepository>();

>>>>>>> parent of 36046e7 (test)



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();//Check cookie if valid

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
