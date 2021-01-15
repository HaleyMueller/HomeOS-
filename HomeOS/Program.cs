using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using ZXing;

namespace HomeOS
{
    public class Program
    {
        //barcode scanner / printer for objects organization, ability to edit save config, turn on and off features

        public static void Main(string[] args)
        {
            BusinessImplementation.SaveFile.LoadFileFromSystem();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.UseKestrel();
                    webBuilder.UseContentRoot(System.IO.Directory.GetCurrentDirectory());
                    //webBuilder.UseUrls("http://localhost:5000");
                    //webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
