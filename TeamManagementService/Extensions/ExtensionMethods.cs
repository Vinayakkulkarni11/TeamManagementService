using System.Text.Json.Serialization;
using TeamManagementService.Middlewares;

namespace TeamManagementService.Extensions
{
    public static class ExtensionMethods
    {
        public static void SetEnumStringConverter(this ModelBuilder modelBuilder)
        {
            var properties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => (Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType).IsEnum);

            foreach (var property in properties)
                property.SetProviderClrType(typeof(string));
        }

        public static void AddCustomServices(this WebApplicationBuilder builder)
        {
            //Added for Enum to string conversions
            builder.Services.AddControllers().AddJsonOptions(opts =>
            {
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);
            });

            //Added for DBContext
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

            builder.Services.AddTransient<IEmployee, EmployeeService>();
            builder.Services.AddTransient<IBusinessUnit, BusinessUnitService>();

        }


        public static void UseCustomMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<LoggingMiddleware>();
        }
    }
}
