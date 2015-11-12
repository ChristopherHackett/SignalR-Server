using Microsoft.AspNet.Builder;
using Microsoft.AspNet.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SignalRSample.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR(options =>
            {
                options.Hubs.EnableDetailedErrors = true;
            });
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseFileServer();
            app.UseStatusCodePages();

            app.UseSignalR<RawConnection>("/raw-connection");
            app.UseSignalR();
        }
    }
}
