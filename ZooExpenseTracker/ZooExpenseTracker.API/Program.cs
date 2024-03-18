using Microsoft.AspNetCore;

namespace ZooExpenseTracker.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                //  .UseKestrel(o => { o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30); })
                .Build();
    }
}