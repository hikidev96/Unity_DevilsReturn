using UnityEngine;

namespace DevilsReturn
{
    public class UIManager : BaseMonoBehaviour
    {
        [SerializeField] private GameObject damageUIPrefab;
        [SerializeField] private GameObject interactionUIPrefab;

        private GameObject interactionUIObj;

        public void InstantiateDamageUI(DamageData damageData, Vector3 position)
        {
            var damageUI = Instantiate(damageUIPrefab, position, Quaternion.identity).GetComponent<DamageUI>();
            damageUI.SetDamageData(damageData);
        }

        public void ShowOrInstantiateInteractionUI(Vector3 position)
        {
            if (interactionUIObj != null)
            {
                interactionUIObj.transform.position = position;
                interactionUIObj.SetActive(true);
                return;
            }

            interactionUIObj = Instantiate(interactionUIPrefab, position, Quaternion.identity);
        }

        public void HideInteractionUI()
        {
            if (interactionUIObj == null) return;

            interactionUIObj.SetActive(false);
        }
    }
}
