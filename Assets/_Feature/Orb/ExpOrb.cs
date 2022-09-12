using UnityEngine;

namespace DevilsReturn
{
    public class ExpOrb : Orb
    {
        [SerializeField] private ScriptableLevelController levelController;
        [SerializeField] private float dividingValue = 2.0f;

        private float exp;

        private void Start()
        {
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f) * (exp / dividingValue);
        }

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