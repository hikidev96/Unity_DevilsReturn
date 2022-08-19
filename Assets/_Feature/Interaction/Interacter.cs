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
                if (interactable != null)
                {
                    interactable.HideInteractionData();
                }

                this.interactable = interactableObjs[0].GetComponent<Interactable>();
                interactable.ShowInteractionData();
            }
            else
            {
                if (interactable != null)
                {
                    interactable.HideInteractionData();
                }

                this.interactable = null;
            }
        }

        public void TryInteract()
        {
            if (interactable == null)
            {
                return;
            }

            interactable.Interact(this);
            interactable.HideInteractionData();
            interactable = null;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(this.transform.position, interactableRange);
        }
    }
}