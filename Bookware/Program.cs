using Bookware.DbServices.Interfaces;
using Bookware.DbServices.Services;
using Bookware.Models;
using Bookware.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BookwareDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BookwareDb")));
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IClassBookService, ClassBookService>();
builder.Services.AddScoped<IEduSubService, EduSubService>();
builder.Services.AddScoped<ITeacherEduService, TeacherEduService>();
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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
