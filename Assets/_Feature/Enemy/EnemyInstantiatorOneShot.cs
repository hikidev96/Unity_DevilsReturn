using UnityEngine;

namespace DevilsReturn
{
    public class EnemyInstantiatorOneShot : BaseMonoBehaviour
    {
        [SerializeField] private PrefabSet enemyPrefabSet;
        [SerializeField] private float delay = 0.0f;

        private void Start()
        {
            Invoke("InstantiateEnemy", delay);
        }

        private void InstantiateEnemy()
        {
            Instantiate(enemyPrefabSet.Get(), this.transform.position, Quaternion.identity);
        }
    }
}