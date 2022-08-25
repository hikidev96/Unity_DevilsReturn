using UnityEngine;

namespace DevilsReturn
{
    public class EnemyInstantiatorOneShot : BaseMonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private float delay = 0.0f;

        private void Start()
        {
            Invoke("InstantiateEnemy", delay);
        }

        private void InstantiateEnemy()
        {
            Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
        }
    }
}