using OrganicBeing.Utilities;
using UnityEngine;

namespace OrganicBeing
{
    public static class OrganicSettings
    {
        private static OrganicConfig _organicConfig;

        private static OrganicConfig OrganicConfig
        {
            get
            {
                if (_organicConfig != null) return _organicConfig;
                _organicConfig = Resources.Load<OrganicConfig>("OrganicConfig");
#if UNITY_EDITOR
                if (_organicConfig == null) OrganicLog.Warn("Missing OrganicConfig. Create it via Tools > OrganicBeing > Create Config Asset");
#endif
                return _organicConfig;
            }
        }

        public static int MaxPoolSize => OrganicConfig?.DefaultMaxPoolSize ?? 100;
        public static EOrganicLogLevel LogLevel => _organicConfig?.LogLevel ?? EOrganicLogLevel.None;
    }
}