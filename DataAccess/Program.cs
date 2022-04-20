using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Program
    {
        public static Contracts.IRepositoryWrapper repos;
        public static EntitiesCore.TMStoresContext dbContext;

        public static void Main(string[] args)
        {
            dbContext = new EntitiesCore.TMStoresContext();
            repos = new Repository.RepositoryWrapper(dbContext);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
