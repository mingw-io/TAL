/// <summary>
/// 
/// </summary>
namespace Gateway.WebApi
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Ocelot.DependencyInjection;
    using Ocelot.Middleware;

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            /*
            services.AddElmahIo(o =>
            {
                o.ApiKey = "ebc6b895f2ab4cf487e92a90a235bb68";
                o.LogId = new Guid("ea0a039f-53af-49af-98a4-0291ecb91660");
            }); */
            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // app.UseElmahIo();
            await app.UseOcelot();
        }
    }
}