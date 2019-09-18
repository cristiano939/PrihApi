using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lime.Protocol.Serialization;
using Lime.Protocol.Serialization.Newtonsoft;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrihApi.Interfaces;
using PrihApi.Services;
using Take.Blip.Client.Extensions;

namespace PrihApi
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
            services.AddMvc().AddJsonOptions(options =>
            {
                foreach (var converter in JsonNetSerializer.Settings.Converters)
                {
                    options.SerializerSettings.Converters.Add(converter);
                }
            });

            var documentResolver = new DocumentTypeResolver();
            documentResolver.WithBlipDocuments();
            services.AddSingleton<IPrihDBManager, PrihDBManager>();
            services.AddSingleton<IDocumentService, DocumentService>();
            services.AddSingleton<IGMapsClient, GMapsClient>();
            services.AddSingleton<IBeerDiscountServices, BeerDiscountServices>();
            services.AddSingleton<IBeerDiscountDBManager, BeerDiscountDBManager>();


            //Takenet.Iris.Messaging.Registrator.RegisterDocuments();

            var envelopeSerializer = new EnvelopeSerializer(documentResolver);
            services.AddSingleton<IEnvelopeSerializer>(envelopeSerializer);
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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
