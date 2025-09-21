#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;
using OrganicBeing.Utilities;

namespace OrganicBeing.Editor
{
    public static class OrganicSettingEditor
    {
        [MenuItem("Tools/OrganicBeing/Create Config Asset")]
        public static void CreateConfig()
        {
            const string resourcesPath = "Assets/Resources";
            const string assetPath = "Assets/Resources/OrganicConfig.asset";

            if (!Directory.Exists(resourcesPath))
            {
                Directory.CreateDirectory(resourcesPath);
            }

            if (File.Exists(assetPath))
            {
                OrganicLog.Info("OrganicConfig already exists.");
                Selection.activeObject = AssetDatabase.LoadAssetAtPath<OrganicConfig>(assetPath);
                return;
            }

            var config = ScriptableObject.CreateInstance<OrganicConfig>();
            AssetDatabase.CreateAsset(config, assetPath);
            AssetDatabase.SaveAssets();

            OrganicLog.Info("OrganicConfig created at Assets/Resources/OrganicConfig.asset");
            Selection.activeObject = config;
        }
    }
}
#endif