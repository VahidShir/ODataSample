using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ODataSample.Models;

namespace ODataSample
{
	public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			var modelBuilder = new ODataConventionModelBuilder();
			modelBuilder.EntityType<Order>();
			modelBuilder.EntitySet<Customer>("Customers");

			builder.Services.AddControllers().AddOData(
				options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null).AddRouteComponents(
					"odata",
					modelBuilder.GetEdmModel()));

			var app = builder.Build();

			app.UseRouting();

			app.MapControllers();

            app.Run();
        }
    }
}
