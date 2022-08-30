using UnityEngine;

namespace DevilsReturn
{
    public class DemonsChestRelicBehaviour : RelicBehaviour
    {
        private HealthPoint healthPoint;

        public override void Activate()
        {
            base.Activate();

            healthPoint = mainObj.GetComponentInChildren<HealthPoint>();
            healthPoint.AddMaxHp(20);
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Renew()
        {
            base.Renew();

            healthPoint.AddMaxHp(20);
        }
    }
}
