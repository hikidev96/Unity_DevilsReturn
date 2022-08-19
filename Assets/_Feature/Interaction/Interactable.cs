using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    [RequireComponent(typeof(BoxCollider))]
    public class Interactable : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Detail")] private bool isCanInterctOnlyOnce;
        [SerializeField, TitleGroup("Detail")] private Transform interactionDataParent;
        [SerializeField, TitleGroup("Event")] private UnityEvent<Interacter> _onInteract;

        public UnityEvent<Interacter> OnInteract => _onInteract;

        private void OnEnable()
        {
            interactionDataParent.gameObject.SetActive(false);
        }

        public void ShowInteractionData()
        {
            interactionDataParent.gameObject.SetActive(true);
        }

        public void HideInteractionData()
        {
            interactionDataParent.gameObject.SetActive(false);
        }

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
