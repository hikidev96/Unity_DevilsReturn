using UnityEngine;

namespace DevilsReturn
{
    public class ExpOrbInstantiator : BaseMonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform instantiationPoint;
        [SerializeField] private Vector2Int countRange;
        [SerializeField] private Vector2 expValueRange;

        public void InstantiateExpOrb()
        {
            var count = Random.Range(countRange.x, countRange.y + 1);

            for (int i = 0; i < count; ++i)
            {
                var expOrb = Instantiate(prefab, instantiationPoint.position, Quaternion.identity).GetComponent<ExpOrb>();
                expOrb.SetExp(Random.Range(expValueRange.x, expValueRange.y));
            }
        }
    }
}