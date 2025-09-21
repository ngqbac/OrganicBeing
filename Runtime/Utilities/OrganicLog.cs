using UnityEngine;

namespace OrganicBeing.Utilities
{
    public static class OrganicLog
    {
        private const string Prefix = "[OrganicBeing]";

        private static EOrganicLogLevel Level => OrganicSettings.LogLevel;

        public static void Info(string message)
        {
            if (!Level.HasFlag(EOrganicLogLevel.Info)) return;
            Debug.Log($"{Prefix} {message}");
        }

        public static void Warn(string message)
        {
            if (!Level.HasFlag(EOrganicLogLevel.Warning)) return;
            Debug.LogWarning($"{Prefix} {message}");
        }

        public static void Error(string message)
        {
            if (!Level.HasFlag(EOrganicLogLevel.Error)) return;
            Debug.LogError($"{Prefix} {message}");
        }

        public static void If(bool condition, string message, EOrganicLogLevel level = EOrganicLogLevel.Info)
        {
            if (!condition || !Level.HasFlag(level)) return;
            Debug.Log($"{Prefix} {message}");
        }
    }
}