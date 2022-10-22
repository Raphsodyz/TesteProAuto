using Application;
using Application.Interfaces;
using Data.Context;
using Data.Repository;
using Data.Repository.Identity;
using Domain.Intefaces;

namespace CadastroWebApi
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<CadastroContext>();

            services.AddCors();

            services.AddTransient<IAssociadoRepository, AssociadoRepository>();
            services.AddTransient<ICarroRepository, CarroRepository>();
            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddTransient<ICadastroUserRepository, CadastroUserRepository>();

            services.AddTransient<IAssociadoApplication, AssociadoApplication>();
            services.AddTransient<ICarroApplication, CarroApplication>();
            services.AddTransient<IEnderecoApplication, EnderecoApplication>();   

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(a => a.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.MapControllers();
        }
    }

    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment enviroment);
        void ConfigureServices(IServiceCollection services);
    }
    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<T>(this WebApplicationBuilder webApplicationBuilder) where T : IStartup
        {
            var startup = Activator.CreateInstance(typeof(T), webApplicationBuilder.Configuration) as IStartup;
            if (startup == null)
            {
                throw new ArgumentException("Classe startup indisponível.");
            }

            startup.ConfigureServices(webApplicationBuilder.Services);

            var app = webApplicationBuilder.Build();

            startup.Configure(app, app.Environment);
            app.Run();

            return webApplicationBuilder;
        }
    }
}
