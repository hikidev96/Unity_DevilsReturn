using UnityEngine;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/ScriptableLevel")]
    public class ScriptableLevelController : ScriptableObject
    {
        private LevelController level;

        public LevelController Get()
        {
            return level;
        }

        public void Set(LevelController level)
        {
            this.level = level;
        }
    }
}
