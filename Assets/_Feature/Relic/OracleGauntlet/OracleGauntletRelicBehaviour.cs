using UnityEngine;

namespace DevilsReturn
{
    public class OracleGauntletRelicBehaviour : RelicBehaviour
    {
        private AttackDamageData attackDamageData;

        public override void Activate()
        {
            base.Activate();

            attackDamageData = mainObj.GetComponentInChildren<AttackDamageData>();
            attackDamageData.AddAttackDamageBase(1);
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Renew()
        {
            base.Renew();

            attackDamageData.AddAttackDamageBase(1);
        }
    }
}
