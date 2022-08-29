using UnityEngine;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/ScriptableLevel")]
    public class ScriptableLevel : ScriptableObject
    {
        private Level level;

        public Level Get()
        {
            return level;
        }

        public void Set(Level level)
        {
            this.level = level;
        }
    }
}
