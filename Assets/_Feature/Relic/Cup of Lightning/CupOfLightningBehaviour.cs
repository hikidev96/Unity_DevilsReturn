using System.Threading.Tasks;
using UnityEngine;

namespace DevilsReturn
{
    public class CupOfLightningBehaviour : RelicBehaviour
    {
        [SerializeField] private GameObject lightningPrefab;

        private float size = 0.5f;

        public override void Activate()
        {
            base.Activate();

            StartToInstantiateLightning();
        }

        public override void Deactivate()
        {
            base.Deactivate();
        }

        public override void Renew()
        {
            base.Renew();

            size += 0.1f;
        }

        private async void StartToInstantiateLightning()
        {
            while (true)
            {                
                await Task.Delay(7000);
                if (mainObj == null) break;

                var lightningObj = GameObject.Instantiate(lightningPrefab, GetRandomPosNearbyPlayer(), Quaternion.identity);
                lightningObj.transform.localScale = new Vector3(size, 1.0f, size);
            }
        }

        private Vector3 GetRandomPosNearbyPlayer()
        {            
            Vector3 result = mainObj.transform.position + (10.0f * new Vector3(VectorHelper.GetRandomDir().x, 0.0f, VectorHelper.GetRandomDir().y));
            return result;
        }
    }
}