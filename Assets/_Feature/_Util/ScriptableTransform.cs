using UnityEngine;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/ScriptableTransform")]
    public class ScriptableTransform : ScriptableObject
    {
        private Transform transform;

        public Transform Get()
        {
            return transform;
        }

        public void Set(Transform transform)
        {
            this.transform = transform;
        }
    }
}
