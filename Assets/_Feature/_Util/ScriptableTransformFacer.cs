using UnityEngine;

namespace DevilsReturn
{
    public class ScriptableTransformFacer : BaseMonoBehaviour
    {
        [SerializeField] private ScriptableTransform playerTrasnform;

        public void Face()
        {
            this.transform.forward = (playerTrasnform.Get().position - this.transform.position).normalized;
        }
    }
}
