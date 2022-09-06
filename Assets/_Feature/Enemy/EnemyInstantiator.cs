using System.Collections;
using UnityEngine;

namespace DevilsReturn
{
    public class EnemyInstantiator : BaseMonoBehaviour
    {
        [SerializeField] private ScriptableTransform playerScriptableTransform;
        [SerializeField] private GameObject enemyPrefab;

        private void Start()
        {
            StartCoroutine(InstantiateEnemyRegularly());
        }

        private IEnumerator InstantiateEnemyRegularly()
        {
            while (true)
            {
                Instantiate(enemyPrefab, GetPosToInstantiate(), Quaternion.identity);

                yield return new WaitForSeconds(3.0f);
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
