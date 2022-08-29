using System.Collections.Generic;
using UnityEngine;

namespace DevilsReturn
{
    public class ParticleSystemColorSetterByTier : BaseMonoBehaviour
    {
        [SerializeField] private ETier tier;
        [SerializeField] private List<ParticleSystem> particleSystems;

        private Color color;

        private void Awake()
        {
            ResetColor();
        }

        public void SetTier(ETier tier)
        {
            this.tier = tier;
            ResetColor();
        }

        private void ResetColor()
        {
            color = Singleton.Game.GetTierColor(tier);

            for (int i = 0; i < particleSystems.Count; ++i)
            {
                var particleSystem = particleSystems[i].main;
                particleSystem.startColor = color;
            }
        }
    }
}