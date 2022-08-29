using UnityEngine;

namespace DevilsReturn
{
    public class MoveData : BaseMonoBehaviour
    {
        [SerializeField] private float moveSpeedBase = 1.0f;

        private float moveSpeedVariance = 1.0f;

        public float MoveSpeed => moveSpeedBase * moveSpeedVariance;

        public void AddMoveSpeedVariance(float amount)
        {
            moveSpeedVariance += amount;
        }
    }
}