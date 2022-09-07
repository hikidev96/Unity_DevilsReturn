using UnityEngine;

namespace DevilsReturn
{
    public class EnemySpellAttack : EnemyAttack
    {
        [SerializeField] private GameObject spellPrefab;

        public void Cast()
        {
            StartCoroutine(StartCoolTime());

            var randomDir = VectorHelper.GetRandomDir();
            Instantiate(spellPrefab, this.transform.position + new Vector3(randomDir.x, 0.0f, randomDir.y) * range, Quaternion.identity);
        }
    }
}