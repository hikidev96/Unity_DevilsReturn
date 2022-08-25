using UnityEngine;

namespace DevilsReturn
{
    public class ScriptableTransformSetter : BaseMonoBehaviour
    {
        [SerializeField] private ScriptableTransform scriptableTransform;

        private void Awake()
        {
            scriptableTransform.Set(this.transform);
        }
    }
}
