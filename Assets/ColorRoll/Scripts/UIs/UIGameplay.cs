using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ColorRoll
{
    public class UIGameplay : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _homeBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _levelText;


        private void Start()
        {
            _levelText.text = $"LEVEL {GameManager.Instance.PlayingLevelData.Level}";

            _homeBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                Loader.Load(Loader.Scene.MenuScene);
            });
        }

        private void OnDestroy()
        {
            _homeBtn.onClick.RemoveAllListeners();
        }
    }
}
