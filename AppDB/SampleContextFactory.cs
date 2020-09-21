using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace CoreWpfApp.AppDB
{
        public class SampleContextFactory : IDesignTimeDbContextFactory<projectappdbContext>
        {
            public projectappdbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<projectappdbContext>();

                // получаем конфигурацию из файла appsettings.json
                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");
                IConfigurationRoot config = builder.Build();

                // получаем строку подключения из файла appsettings.json
                string connectionString = config.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connectionString, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
                return new projectappdbContext(optionsBuilder.Options);
            }
        }
    }


