using UnityEngine;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/RelicData")]
    public class RelicData : ScriptableObject, ICardData
    {
        [SerializeField] private ETier tier;
        [SerializeField, PreviewField] private Sprite relicImage;
        [SerializeField] private GameObject prefab;
        [SerializeField] private LocalizedString relicName;
        [SerializeField] private LocalizedString relicDescription;
        [SerializeReference] private RelicBehaviour behaviour;

        public ETier Tier => tier;
        public GameObject Prefab => prefab;
        public LocalizedString RelicName => relicName;
        public LocalizedString RelicDescription => relicDescription;    
        public RelicBehaviour Behaviour => behaviour;
        public Sprite RelicImage => relicImage;

        LocalizedString ICardData.CardName => relicName;
        LocalizedString ICardData.CardDescription => relicDescription;
    }
}