using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using DG.Tweening;

namespace DevilsReturn
{
    public class CardUI : BaseMonoBehaviour
    {
        [SerializeField] private ScriptableRelicController scriptableRelicController;
        [SerializeField] private Image cardItemFrameImage;
        [SerializeField] private Image cardItemImage;
        [SerializeField] private TextMeshProUGUI cardName;
        [SerializeField] private TextMeshProUGUI cardDescription;
        [SerializeField] private CanvasFader canvasFader;

        private UnityEvent _onSelected;
        private ICardData cardData;

        public CanvasFader CanvasFader => canvasFader;  
        public static UnityEvent<CardUI> OnSomeCardSelected = new UnityEvent<CardUI>();

        private void Awake()
        {
            if (_onSelected == null) _onSelected = new UnityEvent();
        }

        private void OnDestroy()
        {
            _onSelected.RemoveAllListeners();
            OnSomeCardSelected.RemoveAllListeners();
        }

        public void SetCardData(ICardData cardData)
        {
            cardName.text = cardData.CardName.GetString();
            cardDescription.text = cardData.CardDescription.GetString();
            this.cardData = cardData;

            cardName.color = Singleton.Game.GetTierColor(cardData.CardTier);
            cardItemFrameImage.color = Singleton.Game.GetTierColor(cardData.CardTier);


        }

        public void Select()
        {
            scriptableRelicController.Get().EquipRelic(cardData as RelicData);

            _onSelected?.Invoke();
            OnSomeCardSelected?.Invoke(this);
        }
    }
}