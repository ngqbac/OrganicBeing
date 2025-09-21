using System;
using UnityEngine;

namespace OrganicBeing.Utilities
{
    [Flags]
    public enum EOrganicLogLevel
    {
        None    = 0,
        Info    = 1 << 0,
        Warning = 1 << 1,
        Error   = 1 << 2,
        All     = Info | Warning | Error
    }
    
    [CreateAssetMenu(fileName = "OrganicConfig", menuName = "OrganicBeing/Config")]
    public class OrganicConfig : ScriptableObject
    {
        public int DefaultMaxPoolSize = 100;
        public EOrganicLogLevel LogLevel = EOrganicLogLevel.All;
    }
}