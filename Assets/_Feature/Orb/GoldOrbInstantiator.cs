using UnityEngine;

namespace DevilsReturn
{
    public class GoldOrbInstantiator : BaseMonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private Transform instantiationPoint;
        [SerializeField] private Vector2Int countRange;
        [SerializeField] private Vector2Int goldValueRange;

        public void InstantiateGoldOrb()
        {
            var count = Random.Range(countRange.x, countRange.y);

            for (int i = 0; i < count; ++i)
            {
                var goldOrb = Instantiate(prefab, instantiationPoint.position, Quaternion.identity).GetComponent<GoldOrb>();
                goldOrb.SetGold(Random.Range(goldValueRange.x, goldValueRange.y));
            }
        }
    }
}
