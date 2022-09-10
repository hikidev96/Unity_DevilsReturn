using UnityEngine;

namespace DevilsReturn
{
    public class ScriptableLevelControllerSetter : BaseMonoBehaviour
    {
        [SerializeField] private ScriptableLevelController scriptableLevelController;

        private void Awake()
        {
            scriptableLevelController.Set(this.GetComponent<LevelController>());
        }
    }
}
