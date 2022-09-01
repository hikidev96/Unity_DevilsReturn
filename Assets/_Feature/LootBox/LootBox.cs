using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using TMPro;

namespace DevilsReturn
{
    public class LootBox : MonoBehaviour
    {
        [SerializeField, TitleGroup("Detail")] private int price;
        [SerializeField, TitleGroup("Detail")] private TextMeshProUGUI priceTextMesh;
        [SerializeField, TitleGroup("Event")] private UnityEvent _onLootFailed;
        [SerializeField, TitleGroup("Event")] private UnityEvent _onLoot;
        [SerializeField, TitleGroup("Animation")] private Animator animator;
        [SerializeField, TitleGroup("Prefab")] private GameObject openFXPrefab;
        [SerializeField, TitleGroup("Prefab")] private GameObject propFracturePrefab;
        [SerializeField, TitleGroup("Transform")] private Transform boxTrans;
        [SerializeField, TitleGroup("Transform")] private Transform propTrans;
        [SerializeField, TitleGroup("Data")] private PrefabSet prefabsToLoot;
        [SerializeField, TitleGroup("Data")] private ScriptableGoldWallet playerGoldWallet;
        [SerializeField, TitleGroup("Sound")] private SoundData openSoundData;
        [SerializeField, TitleGroup("Sound")] private SoundData dropSoundData;

        private void Start()
        {
            priceTextMesh.text = price.ToString();
        }

        public void Loot()
        {
            if (IsPlayerHasEnoughGold() == false)
            {
                InvokeOnLootFailEvent();                
                return;
            }

            StartCoroutine(StartLootAnimation());
            InvokeOnLootEvent();
        }

        private IEnumerator StartLootAnimation()
        {
            animator.SetTrigger("StartLoot");

            yield return new WaitForSeconds(0.5f);

            animator.SetTrigger("PowerDown");
        }

        private void PowerDown()
        {
            InstantiateExplosionFX();
            InstantiatePropFracture();
            DeactivateSphereObj();
            DeactivatePropObj();
            DropObjs();
            PlayOpenSound();
            Destroy(this.gameObject, 3.0f);
        }

        private void InstantiateExplosionFX()
        {
            Instantiate(openFXPrefab, boxTrans.position, Quaternion.identity);
        }

        private void InstantiatePropFracture()
        {
            Instantiate(propFracturePrefab, propTrans.position, Quaternion.identity);
        }

        protected void DeactivateSphereObj()
        {
            boxTrans.gameObject.SetActive(false);
        }

        protected void DeactivatePropObj()
        {
            propTrans.gameObject.SetActive(false);
        }

        protected void DropObjs()
        {
            if (prefabsToLoot == null)
            {
                return;
            }

            var dropInteraface = Instantiate(prefabsToLoot.Get(), boxTrans.position, Quaternion.identity).GetComponent<IDrop>();

            if (dropInteraface != null)
            {
                dropInteraface.Drop();
                PlayDropSound();
            }
        }

        private void PlayOpenSound()
        {
            Singleton.Audio.Play(openSoundData);
        }

        private void PlayDropSound()
        {
            Singleton.Audio.Play(dropSoundData);
        }

        private bool IsPlayerHasEnoughGold()
        {
            return playerGoldWallet.Get().TryConsumeGold(price);
        }

        private void InvokeOnLootFailEvent()
        {
            _onLootFailed?.Invoke();
        }

        private void InvokeOnLootEvent()
        {
            _onLoot?.Invoke();
        }
    }
}
