using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    [RequireComponent(typeof(BoxCollider))]
    public class Interactable : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Detail")] private bool isCanInterctOnlyOnce;
        [SerializeField, TitleGroup("Event")] private UnityEvent<Interacter> _onInteract;

        public UnityEvent<Interacter> OnInteract => _onInteract;

        public void Interact(Interacter interacter)
        {
            _onInteract?.Invoke(interacter);

            if (isCanInterctOnlyOnce == true)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
