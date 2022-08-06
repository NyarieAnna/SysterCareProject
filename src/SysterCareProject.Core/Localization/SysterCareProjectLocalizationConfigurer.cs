using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace SysterCareProject.Localization
{
    public static class SysterCareProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(SysterCareProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(SysterCareProjectLocalizationConfigurer).GetAssembly(),
                        "SysterCareProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
