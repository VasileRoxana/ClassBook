using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClassBook.Models;
using ClassBook.Repositories.GradeRepository;
using ClassBook.Repositories.StudentRepository;
using ClassBook.Repositories.SubjectGradesRepository;
using ClassBook.Repositories.SubjectRepository;
using ClassBook.Services.StudentService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClassBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ClassBookDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("ClassBookConnectionString")));

            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddControllers();

            //Add repositories
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IGradeRepository, GradeRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<ISubjectGradesRepository, SubjectGradesRepository>();

            //Add services
            services.AddTransient<IStudentService, StudentService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Identity
            services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<ClassBookDbContext>();

            //services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false);
                //.AddEntityFrameworkStores<ClassBookDbContext>();

            services.AddRazorPages(); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
