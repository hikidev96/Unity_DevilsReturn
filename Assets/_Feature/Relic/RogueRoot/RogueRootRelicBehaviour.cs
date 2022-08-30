using UnityEngine;

namespace DevilsReturn
{
    public class RogueRootRelicBehaviour : RelicBehaviour
    {
        private MoveData moveData;

        public override void Activate()
        {
            base.Activate();

            moveData = mainObj.GetComponentInChildren<MoveData>();
            moveData.AddMoveSpeedVariance(0.2f);
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Renew()
        {
            base.Renew();

            moveData.AddMoveSpeedVariance(0.2f);
        }
    }
}
