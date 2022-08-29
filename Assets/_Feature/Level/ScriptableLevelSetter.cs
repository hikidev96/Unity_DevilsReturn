using UnityEngine;

namespace DevilsReturn
{
    public class ScriptableLevelSetter : BaseMonoBehaviour
    {
        [SerializeField] private ScriptableLevel scriptableLevel;

        private void Awake()
        {
            scriptableLevel.Set(this.GetComponent<Level>());
        }
    }
}
