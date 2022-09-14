using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class Relic : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Data"), Required] private RelicData relicData;
        [SerializeField, TitleGroup("Event"), Required] private UnityEvent _onEquip;

        public RelicData RelicData => relicData;
        public RelicBehaviour Behaviour => relicData.Behaviour;

        public void EquipTo(Interacter interacter)
        {
            var relicController = interacter.GetComponentInChildren<RelicController>();

            if (relicController != null)
            {
                relicController.EquipRelic(this);
                InvokeOnEquipEvent();
            }
        }

        public void EquipTo(RelicController relicController)
        {
            if (relicController == null) return;

            relicController.EquipRelic(this);
            InvokeOnEquipEvent();
        }

        private void InvokeOnEquipEvent()
        {
            _onEquip.Invoke();
        }
    }
}