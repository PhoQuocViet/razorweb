using Microsoft.EntityFrameworkCore;
using razorweb.models;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddDbContext<MyBlogContext>(options => {
            string connectionString = builder.Configuration.GetConnectionString("MyBlogContext");
            options.UseSqlServer(connectionString);
        }); //Đăng kí DbContext vào DI của ứng dụng

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
    }
}

/* 
* Cài đặt các package tích hợp Entity Framework:
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet tool install --global dotnet-ef
dotnet tool install --global dotnet-aspnet-codegenerator

* Thư viện Bogus: tự động tạo ra dữ liệu giả định (Fake Data) , có thể chèn những dữ liệu này vào CSDL (seed database)

* Sẽ học trong bài sau: CRUD (Create, Read, Update, Delete)

* Tạo kho chứa Git lưu trữ code và đẩy dự án lên GitHub:
- Bước 1: tạo ra file .gitignore : dotnet new gitignore
- Bước 2: khởi tạo kho chứa git: git init
*/