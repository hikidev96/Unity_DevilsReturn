using UnityEngine;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/ScriptableHealthPoint")]
    public class ScriptableHealthPoint : ScriptableObject
    {
        private HealthPoint healthPoint;

        public HealthPoint Get()
        {
            return healthPoint;
        }

        public void Set(HealthPoint healthPoint)
        {
            this.healthPoint = healthPoint;
        }
    }
}
