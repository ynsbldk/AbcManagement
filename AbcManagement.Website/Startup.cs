using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbcManagement.DataAccess.Data;
using AbcManagement.DataAccess.Repo;
using AbcManagement.Entities.Entities;
using AbcManagement.Website.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper;
using AbcManagement.Website.Mapping;
using AbcManagement.Entities;
using AbcManagement.Entities.IService;
using AbcManagement.Business.Service;
using Smidge;
using Smidge.FileProcessors;

namespace AbcManagement.Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AbcDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("Connection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AbcDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ICategoryService, CategoryService>();
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddSmidge(Configuration.GetSection("smidge"));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IServiceProvider serviceProvider, AbcDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            context.Database.Migrate();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            AddRole.CreateUserRoles(serviceProvider).Wait();

            app.UseSmidge(bundle =>
            {
                bundle.CreateJs(
                    "jsbundle",
                    "~/Theme/files/bower_components/jquery/js/jquery.min.js",
                    "~/Theme/files/bower_components/jquery-ui/js/jquery-ui.min.js",
                    "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js",
                    "~/Theme/files/bower_components/popper.js/js/popper.min.js,",
                    "~/Theme/files/bower_components/bootstrap/js/bootstrap.min.js",
                    "~/Theme/files/bower_components/jquery-slimscroll/js/jquery.slimscroll.js",
                    "~/Theme/files/bower_components/modernizr/js/modernizr.js",
                    "~/Theme/files/bower_components/modernizr/js/css-scrollbars.js",
                    "https://cdn.datatables.net/1.10.21/js/jquery.dataTables.js",
                    "~/Theme/files/bower_components/i18next/js/i18next.min.js",
                    "~/Theme/files/bower_components/i18next-xhr-backend/js/i18nextXHRBackend.min.js",
                    "~/Theme/files/bower_components/i18next-browser-languagedetector/js/i18nextBrowserLanguageDetector.min.js",
                    "~/Theme/files/bower_components/jquery-i18next/js/jquery-i18next.min.js",
                    "~/Theme/files/bower_components/select2/js/select2.full.min.js",
                    "~/Theme/files/assets/pages/advance-elements/select2-custom.js",
                    "~/Theme/files/bower_components/sweetalert/sweetalert2.all.js",
                    "~/Theme/files/assets/js/pcoded.min.js",
                    "~/Theme/files/assets/js/vartical-layout.min.js",
                    "~/Theme/files/assets/js/jquery.mCustomScrollbar.concat.min.js",
                    "~/Theme/files/assets/js/script.js"
                    );
                bundle.CreateCss(
                    "cssbundle",
                    "~/Theme/files/bower_components/select2/css/select2.min.css",
                    "~/Theme/files/bower_components/bootstrap/css/bootstrap.min.css",
                    "~/Theme/files/assets/icon/themify-icons/themify-icons.css",
                    "~/Theme/files/assets/icon/icofont/css/icofont.css",
                    "~/Theme/files/assets/icon/feather/css/feather.css",
                    "https://cdn.datatables.net/1.10.21/css/jquery.dataTables.css",
                    "~/Theme/files/bower_components/datatables.net/PagedList.css",
                    "~/Theme/files/bower_components/sweetalert/css/sweetalert.css",
                    "~/Theme/files/assets/css/style.css",
                    "~/Theme/files/assets/css/jquery.mCustomScrollbar.css"
                    );
                
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
