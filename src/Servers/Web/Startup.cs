namespace HawkLab.Courier.Servers.Web
{
    using HawkLab.Data.Core.Persistence;
    using HawkLab.Data.MongoPersistence;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Serializers;

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
            // This method is deprecated but we need to call it because of a bug in the Mongodb driver.
            #pragma warning disable CS0618
            BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
            #pragma warning restore CS0618
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            services.AddSingleton<IThreadRepository, MongoThreadRepository>();
            services.AddSingleton<IMessageRepository, MongoMessageRepository>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
