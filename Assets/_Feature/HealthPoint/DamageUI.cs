using System.Collections;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace DevilsReturn
{
    public class DamageUI : BaseMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;

        private void Start()
        {
            StartCoroutine(PlayDamageUIAnimation());
        }

        public void SetDamageData(DamageData damageData)
        {
            textMesh.text = damageData.Damage.ToString();
        }

        IEnumerator PlayDamageUIAnimation()
        {
            var startY = this.transform.position.y;

            this.transform.DOPunchScale(new Vector3(0.5f, 0.5f, 0.5f), 0.5f);
            this.transform.DOMoveY(startY + 1.0f, 0.5f);

            yield return new WaitForSeconds(0.5f);

            textMesh.DOFade(0.0f, 0.5f);

            yield return new WaitForSeconds(0.5f);

            Destroy(this.gameObject);
        }
    }
}