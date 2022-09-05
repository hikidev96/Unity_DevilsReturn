using UnityEngine;

namespace DevilsReturn
{
    [CreateAssetMenu(menuName = "DevilsReturn/ScriptableRelicController")]
    public class ScriptableRelicController : ScriptableObject
    {
        private RelicController relicController;

        public RelicController Get()
        {
            return relicController; 
        }

        public void Set(RelicController relicController)
        {
            this.relicController = relicController; 
        }
    }
}
