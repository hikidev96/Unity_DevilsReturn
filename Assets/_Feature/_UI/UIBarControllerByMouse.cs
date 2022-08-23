using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace DevilsReturn
{
    public class UIBarControllerByMouse : BaseMonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler, IPointerClickHandler
    {
        [SerializeField] private RectTransform rt;
        [SerializeField] private Image fillImage;

        private bool isMouseDown;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            SetFillAmount(eventData.position);
        }

        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            isMouseDown = true;
        }

        void IPointerMoveHandler.OnPointerMove(PointerEventData eventData)
        {
            if (isMouseDown == false) return;

            SetFillAmount(eventData.position);
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            isMouseDown = false;
        }

        private void SetFillAmount(Vector2 screenPoint)
        {
            Vector2 clickedPositionInLocal;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, screenPoint, Camera.main, out clickedPositionInLocal);
            fillImage.fillAmount = clickedPositionInLocal.x / rt.sizeDelta.x;
        }
    }
}