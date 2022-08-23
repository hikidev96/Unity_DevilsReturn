using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class Button : BaseMonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField, TitleGroup("Detail")] private bool useDefaultAnimation = true;
        [SerializeField,TitleGroup("Event")] private UnityEvent onClick;
        [SerializeField,TitleGroup("Event")] private UnityEvent onEnter;
        [SerializeField,TitleGroup("Event")] private UnityEvent onExit;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            onClick?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            onEnter?.Invoke();

            if (useDefaultAnimation == true)
            {
                this.transform.DOScale(1.5f, 0.1f).SetUpdate(true);
            }
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (this.gameObject.scene.isLoaded == false) return;

            onExit?.Invoke();

            if (useDefaultAnimation == true)
            {
                this.transform.DOScale(1.0f, 0.1f).SetUpdate(true);
            }                
        }
    }
}
