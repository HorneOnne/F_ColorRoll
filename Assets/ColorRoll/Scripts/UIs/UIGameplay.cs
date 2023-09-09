using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ColorRoll
{
    public class UIGameplay : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button _pauseBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _pauseBtnText;
        [SerializeField] private TextMeshProUGUI _scoreText;



 

        private void Start()
        {
            _pauseBtn.onClick.AddListener(() =>
            {

            });


        }

        private void OnDestroy()
        {
            _pauseBtn.onClick.RemoveAllListeners();
        }
    }
}
