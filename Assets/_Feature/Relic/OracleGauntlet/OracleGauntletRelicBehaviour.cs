using UnityEngine;

namespace DevilsReturn
{
    public class OracleGauntletRelicBehaviour : RelicBehaviour
    {
        private AttackData attackData;

        public override void Activate()
        {
            base.Activate();
            
            attackData = mainObj.GetComponentInChildren<AttackData>();
            attackData.AddDamageBase(1);
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Renew()
        {
            base.Renew();

            attackData.AddDamageBase(1);
        }
    }
}