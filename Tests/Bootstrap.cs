using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Implementations;
using BusinessLogicLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace Tests
{
    public static class Bootstrap
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IWriteable, WriteToFile>();
            /*services.AddTransient<ITest<FirstTest>, FirstTest>();
            services.AddTransient<ITest<SecondTest>, SecondTest>();
            services.AddTransient<ITest<ThirdTest>, ThirdTest>();*/
            ServiceProvider = services.BuildServiceProvider();
        }


    }
}
