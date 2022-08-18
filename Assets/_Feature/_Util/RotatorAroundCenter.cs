using UnityEngine;

namespace DevilsReturn
{
    [RequireComponent(typeof(MeshRenderer))]
    public class RotatorAroundCenter : BaseMonoBehaviour
    {
        [SerializeField] private bool rememberStartRotationAndResetWhenStop;
        [SerializeField] private float rotationSpeed = 5.0f;
        [SerializeField] private Vector3 axis;

        private MeshRenderer meshRenderer;
        private bool isStart;
        private Quaternion startRotation;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            if (isStart == false) return;

            this.transform.RotateAround(meshRenderer.bounds.center, axis, rotationSpeed);
        }

        public void StartRotating()
        {
            startRotation = this.transform.rotation;
            isStart = true;
        }

        public void StopRotating()
        {
            if (rememberStartRotationAndResetWhenStop == true)
            {
                this.transform.rotation = startRotation;
            }
            isStart = false;
        }
    }
}
