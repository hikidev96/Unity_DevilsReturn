using UnityEngine;
using Sirenix.OdinInspector;

namespace DevilsReturn
{    
    [CreateAssetMenu(menuName = "DevilsReturn/GunData")]
    public class GunData : ScriptableObject, ICardData
    {
        [SerializeField, TitleGroup("Mata")] private ETier tier;
        [SerializeField, TitleGroup("Mata")] private LocalizedString gunName;
        [SerializeField, TitleGroup("Mata")] private LocalizedString gunDescription;
        [SerializeField, TitleGroup("Detail")] private float fireRate = 0.2f;
        [SerializeField, TitleGroup("Asset"), AssetsOnly] private GameObject gunPrefab;
        [SerializeField, TitleGroup("Asset"), AssetsOnly] private GameObject fireFXPrefab;
        [SerializeField, TitleGroup("Asset"), AssetsOnly] private GameObject projectilePrefab;
        [SerializeField, TitleGroup("Sound"), AssetsOnly] private SoundData fireSoundData;
        [SerializeField, TitleGroup("Sound"), AssetsOnly] private SoundData equipSoundData;

        public ETier Tier => tier;
        public LocalizedString GunName => gunName;
        public LocalizedString GunDescription => gunDescription;
        public float FireRate => fireRate;
        public GameObject GunPrefab => gunPrefab;
        public GameObject FireFXPrefab => fireFXPrefab;
        public GameObject ProjectilePrefab => projectilePrefab;
        public SoundData FireSoundData => fireSoundData;
        public SoundData EquipSoundData => equipSoundData;

        LocalizedString ICardData.CardName => gunName;
        LocalizedString ICardData.CardDescription => gunDescription;
        ETier ICardData.CardTier => tier;
    }
}