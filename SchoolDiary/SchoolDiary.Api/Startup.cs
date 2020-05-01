namespace SchoolDiary.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using SchoolDiary.Api.Helpers.Config;
    using SchoolDiary.Api.Middleware;
    using SchoolDiary.Api.Services;
    using SchoolDiary.Common.Managers;
    using SchoolDiary.Common.Managers.Fake;
    using SchoolDiary.Common.Services;

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
            //services.AddCors(); // TODO: to allow only for one url
            services.AddControllers();

            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            // Helpers
            services.ConfigureSwagger();
            services.ConfigureIdentityOptions(); // TODO: To analyze
            services.AddJwtAuthorization(Configuration);
            services.AddDbContext(Configuration);

            // Services
            services.AddScoped<ITimeService, TimeService>();
            services.AddScoped<ITokenService, TokenService>();

            //managers
            services.AddScoped<IUserManager, FakeUserManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "School Diary - API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            loggerFactory.AddFile("C:/temp/SchoolDiary/SchoolDiary-{Date}.txt");
        }
    }
}
