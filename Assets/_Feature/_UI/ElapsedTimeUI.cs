using UnityEngine;
using TMPro;

namespace DevilsReturn
{
    public class ElapsedTimeUI : BaseMonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI elapsedTextMesh;

        private void Update()
        {
            elapsedTextMesh.text = $"{(int)(Singleton.Game.ElapsedTime / 60.0f):00}:{Singleton.Game.ElapsedTime % 60.0f:00.}";
        }
    }
}
