using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            string fullFileLink = "D:\\5сем\\РПБДИС\\Курсач\\Lab2\\DBConfiguration.json";
            builder.AddJsonFile(fullFileLink);
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<OrganizationContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
            using(OrganizationContext db = new(options))
            {

            }
        }

    }
}
