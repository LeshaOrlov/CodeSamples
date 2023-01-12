using System;
using Hangfire;
using Hangfire.SqlServer;

namespace HangfireApp
{
    internal class Program
    {
        static void Main()
        {
            GlobalConfiguration.Configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseColouredConsoleLogProvider()
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage("Server=(localdb)\\MSSQLLocalDB; Database=Hangfire.Sample; Integrated Security=True;", new SqlServerStorageOptions());

            RecurringJob.AddOrUpdate(() => Console.WriteLine("Hello, world!"), Cron.Minutely);

            using (var server = new BackgroundJobServer())
            {
                Console.ReadLine();
            }
        }
    }
}
