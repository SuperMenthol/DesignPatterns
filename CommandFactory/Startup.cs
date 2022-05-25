using Domain;
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ProgramNamespace.Interfaces;
using System.Configuration;

namespace ProgramNamespace
{
    public static class Startup
    {
        public static void Build()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ICommandFactory, CommandFactory>()
                .AddDbContext<IPurchaseContext, PurchaseContext>()
                //.AddDbContext<IPurchaseContext, PurchaseContext>(options => options.UseSqlServer(ConfigurationManager.ConnectionStrings["PurchaseEntites"].ConnectionString))
                .BuildServiceProvider();
        }
    }
}