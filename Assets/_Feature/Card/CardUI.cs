using UnityEngine;
using UnityEngine.Events;

namespace DevilsReturn
{
    public class CardUI : BaseMonoBehaviour
    {
        private UnityEvent _onSelected;
        private static UnityEvent<CardUI> OnSomeCardSelected = new UnityEvent<CardUI>();

        private void Awake()
        {
            if (_onSelected == null) _onSelected = new UnityEvent();
        }

        private void OnDestroy()
        {
            _onSelected.RemoveAllListeners();
            OnSomeCardSelected.RemoveAllListeners();
        }        

        public void Select()
        {
            _onSelected.Invoke();
        }
    }
}