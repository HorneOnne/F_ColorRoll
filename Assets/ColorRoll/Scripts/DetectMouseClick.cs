using UnityEngine;

namespace ColorRoll
{
    public class DetectMouseClick : MonoBehaviour
    {
        public event System.Action OnClick;
        [SerializeField] private Paper _paper;

        private void Awake()
        {
            _paper = transform.parent.GetComponent<Paper>();
        }



        public void Click()
        {
            SoundManager.Instance.PlaySound(SoundType.HitBlock, false);
            OnClick?.Invoke();
        }
    }
}
