using UnityEngine;

namespace DevilsReturn
{
    public class ScriptableHealthPointSetter : BaseMonoBehaviour
    {
        [SerializeField] private ScriptableHealthPoint scriptableHealthPoint;

        private void Awake()
        {
            scriptableHealthPoint.Set(this.GetComponent<HealthPoint>());
        }
    }
}
