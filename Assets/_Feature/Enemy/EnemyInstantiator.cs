using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevilsReturn
{
    [System.Serializable]
    public class EnemyInstantiation
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Vector2 instantiationTimeRange;
        [SerializeField] private float interval;

        public GameObject EnemyPrefab => enemyPrefab;
        public Vector2 InstantiationTimeRange => instantiationTimeRange;
        public float Interval => interval;
    }

    public class EnemyInstantiator : BaseMonoBehaviour
    {
        [SerializeField] private List<EnemyInstantiation> instantitations;
        [SerializeField] private ScriptableTransform playerScriptableTransform;

        private void Start()
        {
            for (int i = 0; i < instantitations.Count; ++i)
            {
                var enemyPrefab = instantitations[i].EnemyPrefab;
                var instantiationTimeRange = instantitations[i].InstantiationTimeRange;
                var interval = instantitations[i].Interval;
                StartCoroutine(InstantiateEnemy(enemyPrefab, instantiationTimeRange.x, instantiationTimeRange.y, interval));
            }
        }

        private IEnumerator InstantiateEnemy(GameObject enemyPrefab, float startTime, float endTime, float interval)
        {
            while (true)
            {
                if (Singleton.Game.ElapsedTime < startTime)
                {
                    yield return new WaitForSeconds(1.0f);
                    continue;
                }

                Instantiate(enemyPrefab, GetPosToInstantiate(), Quaternion.identity);
                yield return new WaitForSeconds(interval);

                if (Singleton.Game.ElapsedTime > endTime)
                {
                    yield break;
                }
            }
        }

        private Vector3 GetPosToInstantiate()
        {
            var result = playerScriptableTransform.Get().position;
            var randomValue = Random.Range(0.0f, 1.0f);
            result += new Vector3(randomValue, 0.0f, 1.0f - randomValue) * Camera.main.fieldOfView;
            return result;
        }
    }
}
