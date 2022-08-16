using UnityEngine;

namespace DevilsReturn
{
    public class DestroyerAfterTime : BaseMonoBehaviour
    {
        [SerializeField] private float time = 3.0f;

        private void Start()
        {
            Invoke("DestroySelf", time);
        }

        private void DestroySelf()
        {
            Destroy(this.gameObject);
        }
    }
}