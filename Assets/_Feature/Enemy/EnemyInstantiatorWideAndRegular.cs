using System.Collections;
using UnityEngine;

namespace DevilsReturn
{
    public class EnemyInstantiatorWideAndRegular : BaseMonoBehaviour
    {
        [SerializeField] private GameObject enemyInstantiatorOneShot;
        [SerializeField] private float width;
        [SerializeField] private float height;
        [SerializeField] private Vector2 intervalRange;

        private void Start()
        {
            StartCoroutine(StartInstantiateEnemy());
        }

        private IEnumerator StartInstantiateEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(intervalRange.x, intervalRange.y));
                var randomPos = this.transform.position + new Vector3(Random.Range(-width / 2.0f, width / 2.0f), this.transform.position.y, Random.Range(-height / 2.0f, height / 2.0f));
                Instantiate(enemyInstantiatorOneShot, randomPos, Quaternion.identity);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(this.transform.position, new Vector3(width, 1.0f, height));
        }
    }
}
