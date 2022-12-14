using UnityEngine;

namespace DevilsReturn
{
    public class Singleton : BaseMonoBehaviour
    {
        public static InputManager Input;
        public static AudioManager Audio;
        public static UIManager UI;
        public static CameraManager Camera;
        public static GameManager Game;

        private void Awake()
        {
            Input = GetComponentInChildren<InputManager>();
            Audio = GetComponentInChildren<AudioManager>();
            UI = GetComponentInChildren<UIManager>();
            Camera = GetComponentInChildren<CameraManager>();
            Game = GetComponentInChildren<GameManager>();
        }
    }
}