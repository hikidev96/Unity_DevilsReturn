using System.Collections.Generic;
using UnityEngine;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/PrefabSet")]
    public class PrefabSet : ScriptableObject
    {
        [SerializeField] private List<GameObject> prefabs;

        public GameObject Get()
        {
            if (prefabs == null)
            {
                return null;
            }

            return prefabs[Random.Range(0, prefabs.Count)];
        }
    }
}