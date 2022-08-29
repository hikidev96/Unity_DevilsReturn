using UnityEngine;

namespace DevilsReturn
{
    public class UIManager : BaseMonoBehaviour
    {
        [SerializeField] private GameObject damageUIPrefab;
        [SerializeField] private GameObject interactionUIPrefab;
        [SerializeField] private GameObject gameOverMenuPrefab;

        public void InstantiateDamageUI(DamageData damageData, Vector3 position)
        {
            var damageUI = Instantiate(damageUIPrefab, position, Quaternion.identity).GetComponent<DamageUI>();
            damageUI.SetDamageData(damageData);
        }

        public void InstantiateGameOverMenuAndOpen()
        {
            var gameOverMenuOpener = Instantiate(gameOverMenuPrefab, Vector3.zero, Quaternion.identity).GetComponent<GameOverMenuOpner>();
            gameOverMenuOpener.Open();
        }
    }
}