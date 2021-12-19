using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bicks.Data.DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWorkUnits(this IServiceCollection services)
        {
            //services.AddTransient<ExampleWorkUnit>();

            return services;
        }
    }
}
