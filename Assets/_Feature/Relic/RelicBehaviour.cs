using UnityEngine;

namespace DevilsReturn
{
    public class RelicBehaviour
    {
        protected GameObject mainObj;

        public void SetMainObj(GameObject mainObj)
        {
            this.mainObj = mainObj;
        }

        public virtual void Activate()
        {

        }

        public virtual void Renew()
        {

        }

        public virtual void Deactivate()
        {

        }
    }
}