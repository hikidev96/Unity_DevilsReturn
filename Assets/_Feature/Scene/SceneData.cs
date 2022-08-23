using UnityEngine;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/SceneData")]
    public class SceneData : ScriptableObject
    {
        [SerializeField, TitleGroup("Base")] private string sceneName;

        public string SceneName => sceneName;
    }
}