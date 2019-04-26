using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Data;
using WebApi.GraphQL;
using WebApi.Repository;

namespace WebApi
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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=BookGraphQL;Trusted_Connection=True"));
            services.AddScoped<BookRepository>();
            services.AddScoped<BookType>();
            services.AddScoped<BookMutation>();
            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<BookSchema>();
            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQL<BookSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseMvc();
        }
    }
}
