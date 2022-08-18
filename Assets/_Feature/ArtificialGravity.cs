using UnityEngine;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class ArtificialGravity : BaseMonoBehaviour
    {
        [SerializeField] private float gravity = 30.0f;
        [SerializeField] private float initVelocity = 15.0f;
        [SerializeField] private bool useGroundChecker;
        [SerializeField, ShowIf("@useGroundChecker==true")] private GroundChecker groundChecker;

        public float CurrentVelocty { get; private set; }

        private void OnEnable()
        {
            CurrentVelocty = initVelocity;
        }

        private void Update()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            if (useGroundChecker == true)
            {
                if (groundChecker.IsOnGround == true && CurrentVelocty < 0.0f) return;

                CurrentVelocty -= gravity * Time.deltaTime;
                this.transform.Translate(new Vector3(0.0f, CurrentVelocty * Time.deltaTime, 0.0f), Space.World);
            }
            else
            {
                CurrentVelocty -= gravity * Time.deltaTime;
                this.transform.Translate(new Vector3(0.0f, CurrentVelocty * Time.deltaTime, 0.0f), Space.World);
            }
        }
    }
}
