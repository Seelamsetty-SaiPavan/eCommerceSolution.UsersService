namespace eCommerce.API
{
    using eCommerce.Infrastructure;
    using eCommerce.Core;
    using eCommerce.Core.Mappers;
    using System.Text.Json.Serialization;
    using FluentValidation.AspNetCore;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddInfrastructure();
            builder.Services.AddCore();
            builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
            // Add controllers to the service collection
            builder.Services.AddControllers().AddJsonOptions(options => {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            builder.Services.AddFluentValidationAutoValidation();
            var app = builder.Build();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
