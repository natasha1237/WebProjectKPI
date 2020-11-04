using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebProject.Models;
using Microsoft.Net.Http.Headers;

namespace WebProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc().AddXmlDataContractSerializerFormatters();
            string con = "Data Source=DESKTOP-LTPHR86;Initial Catalog=beautysalon;Integrated Security=True";
            services.AddDbContext<ClientsContext>(options => options.UseSqlServer(con));

           /* services.AddMvc()
              .AddXmlDataContractSerializerFormatters()
              .AddMvcOptions(opts => {
                  opts.FormatterMappings.SetMediaTypeMappingForFormat("xml", new MediaTypeHeaderValue("application/xml"));
              });*/
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /*public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }*/

        public void Configure(IApplicationBuilder app)
         {
            /*app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();*/
            app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
             });
        }
    }
}
