using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.App;
using Application.Interface;
using Domain.Interface;
using Domain.Interface.Generic;
using Infra.Repository;
using Infra.Repository.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dddtest
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
            services.AddMvc();

            services.AddSingleton(typeof(InterfaceGeneric<>), typeof(RepositoryGeneric<>));

            services.AddSingleton<InterfaceProduto, RepositoryProduto>();

            services.AddSingleton<IAppProduto, AppProduto>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
