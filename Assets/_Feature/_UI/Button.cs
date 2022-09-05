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
        [SerializeField, TitleGroup("Detail"), ShowIf("@useDefaultAnimation==true")] private float animationScale = 1.5f;
        [SerializeField,TitleGroup("Event")] private UnityEvent onClick;
        [SerializeField,TitleGroup("Event")] private UnityEvent onEnter;
        [SerializeField,TitleGroup("Event")] private UnityEvent onExit;
        [SerializeField,TitleGroup("Sound")] private SoundData clickSoundData;
        [SerializeField,TitleGroup("Sound")] private SoundData enterSoundData;
        [SerializeField,TitleGroup("Sound")] private SoundData exitSoundData;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            PlayClickSoundData();
            onClick?.Invoke();
        }

        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            PlayEnterSoundData();
            onEnter?.Invoke();

            if (useDefaultAnimation == true)
            {
                this.transform.DOScale(animationScale, 0.1f).SetUpdate(true);
            }
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (this.gameObject.scene.isLoaded == false) return;

            PlayExitSoundData();
            onExit?.Invoke();

            if (useDefaultAnimation == true)
            {
                this.transform.DOScale(1.0f, 0.1f).SetUpdate(true);
            }                
        }

        private void PlayClickSoundData()
        {
            if (clickSoundData == null) return;

            Singleton.Audio.Play(clickSoundData);
        }

        private void PlayEnterSoundData()
        {
            if (enterSoundData == null) return;

            Singleton.Audio.Play(enterSoundData);
        }

        private void PlayExitSoundData()
        {
            if (exitSoundData == null) return;

            Singleton.Audio.Play(exitSoundData);
        }
    }
}
