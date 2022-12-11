using GlobalRank.Core.Interfaces.Repositories;
using GlobalRank.Core.Interfaces.Services;
using GlobalRank.Filters;
using GlobalRank.Infrastructure.Repositories;
using GlobalRank.Services;

namespace GlobalRank.Helpers
{
    public static class DependencyInjection
    {
        public static void InitializeContainer(this IServiceCollection services)
        {
            services.AddScoped<CustomExceptionFilter>();

            services.AddSingleton<IRankRepository, RankRepository>();
            services.AddSingleton<IRankService, RankService>();
        }
    }
}
