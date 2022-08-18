using UnityEngine;

namespace DevilsReturn
{
    public class Interacter : BaseMonoBehaviour
    {
        [SerializeField] private float interactableRange = 1.5f;

        private Interactable interactable;

        private void Start()
        {
            Singleton.Input.OnInteractKeyPress.AddListener(TryInteract);            
        }

        private void Update()
        {
            var interactableObjs = Physics.OverlapSphere(this.transform.position, interactableRange, 1 << LayerMask.NameToLayer("Interactable"));

            if (interactableObjs.Length > 0)
            {
                this.interactable = interactableObjs[0].GetComponent<Interactable>();
                Singleton.UI.ShowOrInstantiateInteractionUI(interactable.transform.position);    
            }
            else
            {
                this.interactable = null;
                Singleton.UI.HideInteractionUI();
            }
        }

        public void TryInteract()
        {
            if (interactable == null)
            {
                return;
            }

            interactable.Interact(this);
            interactable = null;
            Singleton.UI.HideInteractionUI();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(this.transform.position, interactableRange);
        }
    }
}