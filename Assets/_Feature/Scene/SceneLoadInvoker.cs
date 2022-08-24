using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class SceneLoadInvoker : BaseMonoBehaviour
    {
        private enum EScene
        {
            Title,
            Stage
        }

        [SerializeField] private bool useDelay;
        [SerializeField, ShowIf("@useDelay==true")] private float delay;
        [SerializeField] private EScene sceneToLoad;
        [SerializeField] private SceneLoader sceneLoader;

        public void Load()
        {
            if (useDelay == true)
            {
                StartCoroutine(LoadSceneCoroutine());                
            }
            else
            {
                LoadScene();
            }
        }

        private IEnumerator LoadSceneCoroutine()
        {
            yield return new WaitForSecondsRealtime(delay);

            LoadScene();
        }

        private void LoadScene()
        {
            switch (sceneToLoad)
            {
                case EScene.Title:
                    sceneLoader.LoadTitleSceneAsync();
                    break;
                case EScene.Stage:
                    sceneLoader.LoadStageSceneAsync();
                    break;
            }
        }
    }
}
