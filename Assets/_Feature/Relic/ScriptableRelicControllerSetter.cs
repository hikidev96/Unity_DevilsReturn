using UnityEngine;

namespace DevilsReturn
{
    public class ScriptableRelicControllerSetter : BaseMonoBehaviour
    {
        [SerializeField] private ScriptableRelicController scriptableRelicController;

        private void Awake()
        {
            scriptableRelicController.Set(this.GetComponent<RelicController>());
        }
    }
}
