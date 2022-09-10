using System;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class EnemyDatabaseWindow : OdinEditorWindow
    {
        [InlineEditor(InlineEditorModes.LargePreview, Expanded = true)]
        [AssetsOnly]
        public GameObject preview;

        [MenuItem("DevilsReturn/EnemyDatabase", priority = 0)]
        private static void OpenWindow()
        {
            var allAssets = AssetDatabase.FindAssets("t:ScriptableObject", new string[] { "Assets/_Feature/Enemy" });

            Debug.Log(allAssets.Length);

            GetWindow<EnemyDatabaseWindow>().Show();
        }
    }
}