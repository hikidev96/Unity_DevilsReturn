using UnityEngine;

namespace DevilsReturn
{
    public class RelicBehaviour
    {
        protected GameObject mainObj;
        protected int stack = 1;

        public int Stack => stack;

        public void SetMainObj(GameObject mainObj)
        {
            this.mainObj = mainObj;
        }

        public virtual void Activate()
        {
            stack = 1;
        }

        public virtual void Renew()
        {
            stack += 1;
        }

        public virtual void Deactivate()
        {
            mainObj = null;
        }
    }
}