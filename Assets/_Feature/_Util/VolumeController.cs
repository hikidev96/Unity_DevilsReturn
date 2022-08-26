using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/VolumeController")]
    public class VolumeController : ScriptableObject
    {
        [SerializeField] private VolumeProfile profile;

        Tweener hitEffetTweener;

        public void PlayHitEffect()
        {
            var vignette = GetVignette();

            vignette.color.value = Color.red;
            vignette.intensity.value = 0.5f;

            if (hitEffetTweener != null)
            {
                hitEffetTweener.Kill();
            }
            hitEffetTweener = DOTween.To(() => vignette.intensity.value, (value) => vignette.intensity.value = value, 0.0f, 1.0f);
        }

        private Vignette GetVignette()
        {
            Vignette vignette;
            profile.TryGet(out vignette);
            return vignette;
        }
    }
}