using Microsoft.Extensions.DependencyInjection;
using Tmdt.Domain.Interfaces;
using Tmdt.Infrastructure.Persistence.Services;

namespace Tmdt.Infrastructure.Persistence.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<ICartService, CartService>();
        }
    }
}
