using UnityEngine;

namespace DevilsReturn
{
    public class ExpOrb : Orb
    {
        [SerializeField] private ScriptableLevelController level;

        private float exp;

        public override void Activate()
        {
            if (isActivated == true) return;

            base.Activate();    

            level.Get().AddExp(exp);            
            DestroySelf();            
        }

        public void SetExp(float exp)
        {
            this.exp = exp;
        }
    }
}