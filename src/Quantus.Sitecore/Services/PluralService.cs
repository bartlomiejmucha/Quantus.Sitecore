using System.Linq;
using Quantus.Providers;
using Quantus.Sitecore.Repositories;

namespace Quantus.Sitecore.Services
{
    public static class PluralService
    {
        public static PluralCategory GetPluralCategory(string language, decimal quantity)
        {
            var provider = PluralProviderRepository.All.FirstOrDefault(x => x.Name == language) as IPluralProvider ?? PluralProviderRepository.DefaultPluralProvider;

            return provider.GetPluralCategory(quantity);
        }
    }
}