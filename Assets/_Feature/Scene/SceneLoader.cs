using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/SceneLoader")]
    public class SceneLoader : ScriptableObject
    {
        [SerializeField] private SceneData titleSceneData;
        [SerializeField] private SceneData stageSceneData;

        [Button]
        public void LoadTitleSceneAsync()
        {
            SceneManager.LoadSceneAsync(titleSceneData.SceneName);
        }

        [Button]
        public void LoadStageSceneAsync()
        {
            SceneManager.LoadSceneAsync(stageSceneData.SceneName);
        }
    }
}
