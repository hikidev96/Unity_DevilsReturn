using DG.Tweening;

namespace DevilsReturn
{
    public class Timer
    {
        private float current;
        private Tweener timerTweener;

        public float Current => current;

        public void StartTimer(float duration, TweenCallback callback = null)
        {
            timerTweener = DOTween.To(() => current, (x) => current = x, duration, duration);
            timerTweener.SetEase(Ease.Linear);
            timerTweener.onComplete += callback;
            timerTweener.onComplete += () => current = 0;
        }

        public void ResumeTimer()
        {
            timerTweener.Play();
        }

        public void StopTimer()
        {
            timerTweener.Pause();
        }
    }
}