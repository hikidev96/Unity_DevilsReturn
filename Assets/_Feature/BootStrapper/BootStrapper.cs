using UnityEngine;

namespace SOD
{
    public static class BootStrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void CreateNeededObjectsBeforeSceneLoad()
        {
            var singletonPrefab = Resources.Load<GameObject>("Singleton");
            var singletonObj = GameObject.Instantiate(singletonPrefab);
            GameObject.DontDestroyOnLoad(singletonObj);
        }
    }
}
