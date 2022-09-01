using UnityEngine;

namespace DevilsReturn
{
    public class CameraShakerInvoker : BaseMonoBehaviour
    {
        [SerializeField] private float power = 4.0f;

        public void Invoke()
        {
            Singleton.Camera.Shake(power);
        }
    }
}
