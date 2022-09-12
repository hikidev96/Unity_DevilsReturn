using UnityEngine;
using UnityEngine.Events;

namespace DevilsReturn
{
    public class Ground : BaseMonoBehaviour
    {
        public bool isNeighborGround = true;

        private UnityEvent<Ground> _onPlayerEnter;

        public UnityEvent<Ground> OnPlayerEnter => _onPlayerEnter;

        private void Awake()
        {
            if (_onPlayerEnter == null) _onPlayerEnter = new UnityEvent<Ground>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player") == true)
            {
                _onPlayerEnter?.Invoke(this);
            }
        }
    }
}