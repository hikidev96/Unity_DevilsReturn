using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace DevilsReturn
{
    public class FakeJumper : BaseMonoBehaviour
    {
        [SerializeField, BoxGroup("Detail")] private float groundCheckDistance = 0.3f;
        [SerializeField, BoxGroup("Detail")] private float gravity = 30.0f;
        [SerializeField, BoxGroup("Detail")] private Vector2 initVelocity_Range_X;
        [SerializeField, BoxGroup("Detail")] private Vector2 initVelocity_Range_Y;
        [SerializeField, BoxGroup("Detail")] private Vector2 initVelocity_Range_Z;
        [SerializeField, BoxGroup("Event")] private UnityEvent _onGround;

        public float CurrentVelocty_Y { get; private set; }
        public Vector2 Dir { get; private set; }
        public bool IsOnGround { get; private set; }

        private void OnEnable()
        {
            CurrentVelocty_Y = GetRandomValue(initVelocity_Range_Y.x, initVelocity_Range_Y.y);
            Dir = new Vector2(GetRandomValue(initVelocity_Range_X.x, initVelocity_Range_X.y), GetRandomValue(initVelocity_Range_Z.x, initVelocity_Range_Z.y));
        }

        private void Update()
        {
            UpdatePosition();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        private void UpdatePosition()
        {
            if (IsOnGround == true && CurrentVelocty_Y < 0.0f) return;

            CurrentVelocty_Y -= gravity * Time.deltaTime;
            this.transform.Translate(new Vector3(Dir.x, CurrentVelocty_Y, Dir.y) * Time.deltaTime, Space.World);            
        }      

        private void CheckGround()
        {
            if (IsOnGround == true)
            {
                return;
            }

            if (Physics.Raycast(this.transform.position, Vector3.up * -1, groundCheckDistance, 1 << LayerMask.NameToLayer("Ground")) == true)
            {
                IsOnGround = true;
                _onGround?.Invoke();
            }
            else
            {
                IsOnGround = false;
            }
        }

        private float GetRandomValue(float min, float max)
        {
            return Random.Range(min, max);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(this.transform.position, this.transform.position + (Vector3.up * -1) * groundCheckDistance);
        }
    }
}