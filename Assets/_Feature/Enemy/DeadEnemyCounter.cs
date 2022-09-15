using UnityEngine;

namespace DevilsReturn
{
    public class DeadEnemyCounter : BaseMonoBehaviour
    {
        private void OnDestroy()
        {
            Singleton.Game.DeadEnemyCount++;
        }        
    }
}
