using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MVC.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var port = 45000;

            var builder = new WebHostBuilder();
            using (var host = builder.UseUrls($"http://127.0.0.1:{port}").UseKestrel().UseStartup<Startup>().Build())
            {
                host.Start();
                host.WaitForShutdown();
            }
        }

    }
}
