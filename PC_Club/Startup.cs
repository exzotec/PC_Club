using PC_Club.Extensions;
using PC_Club.Services;
using PC_Club.Repositories;
using System.Text.Json;

namespace PC_Club
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
            //string connection = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<DataContext>(options =>
            //options.UseNpgsql(connection));

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler =
                        System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                });

            services.AddAsymmetricAuthentication();

            services.AddTransient<AuthenticationService>();
            services.AddTransient<UserService>();
            services.AddTransient<TokenService>();
            services.AddTransient<UserRepository>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages("text/plain", "Error. Status code : {0}");

            app.UseRouting();

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
