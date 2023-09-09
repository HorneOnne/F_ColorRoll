using UnityEngine;
using UnityEngine.UI;

namespace ColorRoll
{
    public class UIMainMenu : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _playBtn;
        [SerializeField] private Button _newgameBtn;
        [SerializeField] private Button _settingsBtn;

        private void Start()
        {
            _playBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                Loader.Load(Loader.Scene.GameplayScene);
            });

            _newgameBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                GameManager.Instance.ResetLevel();
                Loader.Load(Loader.Scene.GameplayScene);             
            });

            _settingsBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.PlaySound(SoundType.Button, false);

                UIManager.Instance.CloseAll();
                UIManager.Instance.DisplaySettingsMenu(true);
            });
        }

        private void OnDestroy()
        {
            _playBtn.onClick.RemoveAllListeners();
            _settingsBtn.onClick.RemoveAllListeners();
            _newgameBtn.onClick.RemoveAllListeners();
        }
    }
}
