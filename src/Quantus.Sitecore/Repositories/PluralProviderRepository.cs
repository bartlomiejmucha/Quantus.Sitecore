using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using Quantus.Providers;
using Sitecore.Configuration;
using Sitecore.Configuration.Providers;

namespace Quantus.Sitecore.Repositories
{
    public static class PluralProviderRepository
    {
        private static IEnumerable<ProviderBase> _all;
        private static IPluralProvider _defaultPluralProvider;

        public static IEnumerable<ProviderBase> All
        {
            get
            {
                if (_all == null)
                {
                    Initialize();
                }

                return _all;
            }
        }

        public static IPluralProvider DefaultPluralProvider
        {
            get
            {
                if (_defaultPluralProvider == null)
                {
                    Initialize();
                }

                return _defaultPluralProvider;
            }
        }

        private static void Initialize()
        {
            var providers = Factory.GetProviders<ProviderBase, ProviderCollectionBase<ProviderBase>>("quantus", out var defaultProvider);
            if (!(defaultProvider is IPluralProvider defaultSearchResultFormatter))
            {
                throw new ConfigurationErrorsException("The default quantus provider must derive from IPluralProvider");
            }

            _all = providers;
            _defaultPluralProvider = defaultSearchResultFormatter;
        }
    }
}