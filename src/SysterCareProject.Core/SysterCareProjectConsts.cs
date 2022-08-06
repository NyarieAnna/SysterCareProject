using SysterCareProject.Debugging;

namespace SysterCareProject
{
    public class SysterCareProjectConsts
    {
        public const string LocalizationSourceName = "SysterCareProject";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "cb0f075bee824f528d200dd3e518f2c2";
    }
}
