using System.Collections;
using UnityEngine;

namespace DevilsReturn
{
    public class EnemyInstantiatorRegular : BaseMonoBehaviour
    {
        [SerializeField] private GameObject enemyInstantiatorOneShot;

        private void Start()
        {
            StartCoroutine(StartInstantiateEnemy());
        }

        private IEnumerator StartInstantiateEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
                Instantiate(enemyInstantiatorOneShot, this.transform.position, Quaternion.identity);
            }
        }
    }
}