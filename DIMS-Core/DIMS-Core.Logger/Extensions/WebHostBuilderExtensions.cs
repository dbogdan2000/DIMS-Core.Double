using Microsoft.AspNetCore.Hosting;
using NLog.Web;

namespace DIMS_Core.Logger.Extensions
{
    public static class WebHostBuilderExtensions
    {
        private const string DefaultConfigFileName = "nlogconfig.json";

        public static IWebHostBuilder UseCustomNLog(this IWebHostBuilder builder, string configFileName = DefaultConfigFileName)
        {
            return builder.ConfigureLogging(logging =>
                                            {
                                                logging.ConfigureNlogByJson(configFileName);
                                            })
                          .UseNLog();
        }
    }
}