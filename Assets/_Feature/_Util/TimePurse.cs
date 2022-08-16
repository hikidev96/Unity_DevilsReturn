using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DevilsReturn
{
    public class TimePurse : BaseMonoBehaviour
    {
        [SerializeField] private float time;
        [SerializeField] private UnityEvent _onPurse;        

        private void Start()
        {
            StartCoroutine(StartTimePurse());
        }

        private IEnumerator StartTimePurse()
        {
            yield return new WaitForSeconds(time);
            _onPurse?.Invoke();
        }
    }
}
