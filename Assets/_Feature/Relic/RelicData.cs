using UnityEngine;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/RelicData")]
    public class RelicData : ScriptableObject
    {
        [SerializeField] private ETier tier;
        [SerializeField] private GameObject prefab;
        [SerializeField] private LocalizedString relicName;
        [SerializeField] private LocalizedString relicDescription;
        [SerializeReference] private RelicBehaviour behaviour;

        public ETier Tier => tier;
        public GameObject Prefab => prefab;
        public LocalizedString RelicName => relicName;
        public LocalizedString RelicDescription => relicDescription;    
        public RelicBehaviour Behaviour => behaviour;   
    }
}
