using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class LootBox : MonoBehaviour
    {
        [SerializeField, TitleGroup("Event")] private UnityEvent _onLoot;
        [SerializeField, TitleGroup("Animation")] private Animator animator;
        [SerializeField, TitleGroup("Prefab")] private GameObject openFXPrefab;
        [SerializeField, TitleGroup("Prefab")] private GameObject propFracturePrefab;
        [SerializeField, TitleGroup("Transform")] private Transform boxTrans;
        [SerializeField, TitleGroup("Transform")] private Transform propTrans;
        [SerializeField, TitleGroup("Data")] private PrefabSet prefabsToLoot;
        [SerializeField, TitleGroup("Sound")] private SoundData openSoundData;

        public void Loot()
        {
            StartCoroutine(StartLootLogic());

            _onLoot?.Invoke();
        }        

        private IEnumerator StartLootLogic()
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
            }
        }

        private void PlayOpenSound()
        {
            Singleton.Audio.Play(openSoundData);
        }
    }
}
