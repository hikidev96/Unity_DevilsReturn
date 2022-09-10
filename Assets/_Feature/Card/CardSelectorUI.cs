using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using DG.Tweening;

namespace DevilsReturn
{
    public class CardSelectorUI : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Detail")] private List<CardUI> cards;
        [SerializeField, TitleGroup("Detail")] private CanvasFader canvasFader;
        [SerializeField, TitleGroup("Detail")] private CanvasGroup canvasGroupForCards;
        [SerializeField, TitleGroup("Detail")] private ScriptableLevelController playerLevel;
        [SerializeField, TitleGroup("Detail")] private ScriptableObjectSet relicDataSet;
        [SerializeField, TitleGroup("Event")] private UnityEvent _onOpen;
        [SerializeField, TitleGroup("Event")] private UnityEvent _onClose;

        private void Awake()
        {
            CardUI.OnSomeCardSelected.AddListener(Close);

            playerLevel.Get().OnLevelUp.AddListener(() => Open(relicDataSet));
        }

        [Button]
        public void Open(ScriptableObjectSet dataSet)
        {
            Singleton.Input.DisableAttackInput();
            Singleton.Input.DisableInteractionInput();
            Singleton.Input.DisableMovementInput();

            EnableCardsButton();
            SetCardDataToCards(dataSet);
            StartCoroutine(StartOpenLogic());
            _onOpen?.Invoke();
        }

        [Button]
        public void Close(CardUI selectedCard)
        {
            Singleton.Input.EnableAttackInput();
            Singleton.Input.EnableInteractionInput();
            Singleton.Input.EnableMovementInput();

            DisableCardsButton();
            StartCoroutine(StartCloseLogic(selectedCard));
            _onClose?.Invoke();
        }

        private IEnumerator StartOpenLogic()
        {
            for (int i = 0; i < cards.Count; ++i)
            {                
                cards[i].CanvasFader.FadeIn();
            }

            Singleton.Camera.FadeIn();
            Singleton.Game.Pause();

            yield return new WaitForSecondsRealtime(0.2f);

            canvasFader.FadeIn();
            ShowUpCards();
        }

        private IEnumerator StartCloseLogic(CardUI selectedCard)
        {
            HideUnselectedCard(selectedCard);

            yield return new WaitForSecondsRealtime(0.4f);

            Singleton.Camera.FadeOut();
            Singleton.Game.Resume();
            canvasFader.FadeOut();
        }

        private void ShowUpCards()
        {
            cards[0].transform.localPosition = new Vector3(-500.0f, -150.0f, 0.0f);
            cards[1].transform.localPosition = new Vector3(0.0f, -150.0f, 0.0f);
            cards[2].transform.localPosition = new Vector3(500.0f, -150.0f, 0.0f);

            cards[0].transform.DOLocalMoveY(0.0f, 0.3f).SetUpdate(true);
            cards[1].transform.DOLocalMoveY(0.0f, 0.3f).SetUpdate(true);
            cards[2].transform.DOLocalMoveY(0.0f, 0.3f).SetUpdate(true);
        }

        private void HideUnselectedCard(CardUI selectedCard)
        {
            selectedCard.transform.DOLocalMoveX(0.0f, 0.3f).SetUpdate(true).SetEase(Ease.InQuint);

            for (int i = 0; i < cards.Count; ++i)
            {
                if (cards[i] == selectedCard) continue;

                cards[i].CanvasFader.FadeOut();
            }
        }

        private void SetCardDataToCards(ScriptableObjectSet dataSet)
        {
            var cardDataList = new List<ICardData>();

            while (true)
            {
                if (cardDataList.Count == 3) break;

                var cardData = dataSet.Get();

                if (cardDataList.Contains(cardData as ICardData) == false)
                {
                    cardDataList.Add(cardData as ICardData);
                    cards[cardDataList.Count - 1].SetCardData(cardDataList[cardDataList.Count - 1]);
                }
            }
        }

        private void DisableCardsButton()
        {
            canvasGroupForCards.blocksRaycasts = false;
            canvasGroupForCards.interactable = false;
        }

        private void EnableCardsButton()
        {
            canvasGroupForCards.blocksRaycasts = true;
            canvasGroupForCards.interactable = true;
        }
    }
}