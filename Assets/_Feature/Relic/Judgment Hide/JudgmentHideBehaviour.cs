using UnityEngine;

namespace DevilsReturn
{
    public class JudgmentHideBehaviour : RelicBehaviour
    {
        private AttackData attackData;

        public override void Activate()
        {
            base.Activate();

            attackData = mainObj.GetComponentInChildren<AttackData>();
            attackData.AddCriticalChance(5);
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Renew()
        {
            base.Renew();

            attackData.AddCriticalChance(5);
        }
    }
}