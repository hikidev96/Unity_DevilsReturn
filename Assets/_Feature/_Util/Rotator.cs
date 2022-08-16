using UnityEngine;
using UnityEngine.InputSystem;

namespace DevilsReturn
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private Transform trans;
        [SerializeField] private float smoothRotationSpeed = 0.5f;

        public void RotateSmoothly(Vector3 dir, bool considerCamera = false)
        {
            var goalRot = GetGoalRot(dir, considerCamera);
            trans.rotation = Quaternion.Slerp(trans.rotation, goalRot, smoothRotationSpeed);
        }

        public void RotateDirectly(Vector3 dir, bool considerCamera = false)
        {
            var goalRot = GetGoalRot(dir, considerCamera);
            trans.rotation = goalRot;
        }

        public void RotateTowardMouseDirectly()
        {
            var dir = GetDirTowardMouse();
            RotateDirectly(new Vector3(dir.x, 0.0f, dir.z));
        }

        public void RotateTowardMouseSmoothly()
        {
            var dir = GetDirTowardMouse();
            RotateSmoothly(new Vector3(dir.x, 0.0f, dir.z));
        }

        public void SetRotationSpeed(float value)
        {
            smoothRotationSpeed = value;  
        }

        private Vector3 GetDirTowardMouse()
        {
            RaycastHit hit;
            Vector3 result = Vector3.zero;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit, 1000.0f, LayerMask.GetMask("Ground")) == true)
            {
                result = (hit.point - trans.position).normalized;
            }

            return result;
        }

        private Quaternion GetGoalRot(Vector3 dir, bool considerCamera = false)
        {
            if (dir == Vector3.zero) return Quaternion.identity;

            return Quaternion.LookRotation(dir) * GetCameraRot(considerCamera);
        }

        private Quaternion GetCameraRot(bool considerCamera)
        {
            return considerCamera ? Quaternion.Euler(new Vector3(0.0f, Camera.main.transform.rotation.eulerAngles.y, 0.0f)) : Quaternion.Euler(Vector3.zero);
        }
    }
}