using Microsoft.AspNetCore.Mvc;
using ZooExpenseTracker.Lib.Interface;
using ZooExpenseTracker.Lib.Services;

namespace ZooExpenseTracker.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddSingleton<IFileValidation, FileValidation>();
            services.AddSingleton<IDataFileReader, DataFileReader>();
            services.AddSingleton<IFeedingCostCalculator, FeedingCostCalculator>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            // Configure endpoints for API actions
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();



        }

    }
}

