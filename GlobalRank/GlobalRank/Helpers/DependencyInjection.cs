using GlobalRank.Core.Interfaces.Repositories;
using GlobalRank.Core.Interfaces.Services;
using GlobalRank.Infrastructure.Repositories;
using GlobalRank.Services;

namespace GlobalRank.Helpers
{
    public static class DependencyInjection
    {
        public static void InitializeContainer(this IServiceCollection services)
        {
            services.AddSingleton<IRankRepository, RankRepository>();
            services.AddSingleton<IRankService, RankService>();
        }
    }
}
