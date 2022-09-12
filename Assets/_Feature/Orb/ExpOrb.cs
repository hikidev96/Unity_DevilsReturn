using UnityEngine;

namespace DevilsReturn
{
    public class ExpOrb : Orb
    {
        [SerializeField] private ScriptableLevelController levelController;

        private float exp;

        public override void Activate()
        {
            if (isActivated == true) return;

            base.Activate();    

            levelController.Get().AddExp(exp);            
            DestroySelf();            
        }

        public void SetExp(float exp)
        {
            this.exp = exp;
        }
    }
}