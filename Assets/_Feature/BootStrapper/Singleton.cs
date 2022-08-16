using UnityEngine;

namespace DevilsReturn
{
    public class Singleton : BaseMonoBehaviour
    {
        public static InputManager Input;
        public static AudioManager Audio;

        private void Awake()
        {
            Input = GetComponentInChildren<InputManager>();
            Audio = GetComponentInChildren<AudioManager>();   
        }
    }
}