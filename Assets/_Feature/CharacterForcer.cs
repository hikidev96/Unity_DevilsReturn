using UnityEngine;

namespace DevilsReturn
{
    public class CharacterForcer : BaseMonoBehaviour
    {        
        [SerializeField] private float mass = 1.0f;

        private Vector3 currentPower = Vector3.zero;
        private CharacterController characterController;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (currentPower.magnitude > 0.2f)
            {
                characterController.SimpleMove(currentPower);                
            }

            currentPower = Vector3.Lerp(currentPower, Vector3.zero, 5 * Time.deltaTime);
        }

        public void AddForceToFoward(float power)
        {
            AddForce(this.transform.forward, power);
        }

        public void AddForce(Vector3 dir, float power)
        {
            dir.y = 0.0f;
            currentPower += dir * power / mass;
        }

        public void AddForce(DamageData damageData)
        {                        
            AddForce(damageData.Dir, 5);
        }
    }
}