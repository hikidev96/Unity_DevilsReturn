using UnityEngine;

namespace DevilsReturn
{
    public class Singleton : BaseMonoBehaviour
    {
        public static InputManager Input;

        private void Awake()
        {
            Input = GetComponentInChildren<InputManager>();
        }
    }
}
