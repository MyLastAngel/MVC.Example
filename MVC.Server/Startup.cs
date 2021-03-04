using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using MVC.Server.Managers;

namespace MVC.Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var controllers = ExternalManager.ExternalControllers;

            // Добавляем наш список контролеров к приложению
            services.AddMvc().ConfigureApplicationPartManager(app =>
              {
                  var p = new ExternalPartsProvider(controllers);
                  app.ApplicationParts.Add(p);
              });

            // Добавляем ссылки на файлы View для контролера
            //services.Configure<RazorViewEngineOptions>(options =>
            //{
            //    var eFiles = controllers.Select(c => new EmbeddedFileProvider(c.Assembly, c.Namespace));
            //    options.FileProviders.Add(new CompositeFileProvider(eFiles));
            //});

            services.AddControllersWithViews().AddRazorRuntimeCompilation(options =>
            {
                options.FileProviders.Clear();

                var eFiles = controllers.Select(c => new EmbeddedFileProvider(c.Assembly, c.Namespace));
                options.FileProviders.Add(new CompositeFileProvider(eFiles));
            });


            services.Configure<MvcOptions>(opt =>
            {
                opt.EnableEndpointRouting = false;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMvcWithDefaultRoute();
        }
    }
}
