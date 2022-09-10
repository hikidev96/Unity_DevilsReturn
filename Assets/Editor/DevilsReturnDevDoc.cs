using System;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class DevilsReturnDevDoc : OdinEditorWindow
    {
        [MenuItem("DevilsReturn/Doc", priority = 1)]
        private static void OpenWindow()
        {
            Application.OpenURL("https://www.notion.so/Devil-s-Return-Dev-Doc-245e7bb721dc46c8a38f33fb3beb08c2");
        }
    }
}
