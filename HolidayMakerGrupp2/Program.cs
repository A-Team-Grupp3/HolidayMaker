using HolidayMakerGrupp2.Models.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HolidayMakerGrupp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateDB();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async void CreateDB()
        {
            using (var context = new HolidayMakerGrupp2Context())
            {
                await context.Database.MigrateAsync();
                await context.SaveChangesAsync();
            }
        }
    }
}