using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Tutorial.AspNetSecurity.RouxAcademy.DataServices;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;

namespace Tutorial.AspNetSecurity.RouxAcademy
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Register Student database context
            services.AddDbContext<StudentDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RouxAcademy")));

            services.AddDbContext<IdentityDbContext>(options => 
                options.UseSqlServer(
                    Configuration.GetConnectionString("RouxAcademy"),
                    optionsBuilders =>
                        optionsBuilders.MigrationsAssembly("Tutorial.AspNetSecurity.RouxAcademy")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            var secret = Configuration["PaymentProcessorPassword"];

            services.Configure<MvcOptions>(options =>
                {
                    options.Filters.Add(new RequireHttpsAttribute());
                });

            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("FacultyOnly",
                    policy => 
                        policy.RequireClaim("FacultyNumber"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var rewriteOptions = new RewriteOptions().AddRedirectToHttps();

            app.UseRewriter(rewriteOptions);

            app.UseStaticFiles();

            // Enable ASP.Net cookie based identity
            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
