using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;

namespace ToDoList
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IApplicationEnvironment appEnv, IHostingEnvironment env)
        {
            var configBuilder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json", optional: true);

            if (env.IsDevelopment())
            {
                configBuilder.AddUserSecrets();
            }

            configBuilder.AddEnvironmentVariables();
            Configuration = configBuilder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services
                .AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ToDoContext>(options => options.UseSqlServer(Configuration["SQLAZURECONNSTR_ToDoListDb"]));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Todo", action = "Index" });
            });
        }
    }
}
