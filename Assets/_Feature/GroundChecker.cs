using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class GroundChecker : BaseMonoBehaviour
    {
        [SerializeField, TitleGroup("Detail")] private float groundCheckDistance = 0.3f;

        public bool IsOnGround { get; private set; }

        private void Update()
        {
            CheckGround();
        }

        private void CheckGround()
        {
            if (Physics.Raycast(this.transform.position, Vector3.up * -1, groundCheckDistance, 1 << LayerMask.NameToLayer("Ground")) == true)
            {
                IsOnGround = true;
            }
            else
            {
                IsOnGround = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(this.transform.position, this.transform.position + (Vector3.up * -1) * groundCheckDistance);
        }
    }
}