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

        //private void OnMouseDown()
        //{
        //    OnClick?.Invoke();
        //}

        public void Click()
        {
            OnClick?.Invoke();
        }
    }
}
