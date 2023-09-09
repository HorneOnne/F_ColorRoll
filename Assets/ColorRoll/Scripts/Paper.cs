using System.Collections;
using UnityEngine;

namespace ColorRoll
{
    public class Paper : MonoBehaviour
    {
        public static event System.Action<Paper> OnChangeState;

        private SpriteRenderer _childSR;
        private DetectMouseClick _detectMouseClick;

        public enum State
        {
            ON, OFF
        }
        [SerializeField] private State _state;

        [Header("Properties")]
        [SerializeField] private Vector2 _onScale;
        [SerializeField] private Vector2 _offScale;
        private bool _isMoveFinished = true;

        #region Properties
        public SpriteRenderer SpiteRenderer { get => _childSR; }
        public State PaperState { get => _state; }
        #endregion

        private void Start()
        {
            _state = State.OFF;

            _detectMouseClick = transform.GetComponentInChildren<DetectMouseClick>();
            _childSR = transform.GetComponentInChildren<SpriteRenderer>();
            _childSR.sortingOrder = 99;

            _detectMouseClick.OnClick += ToggleState;
        }


        public void ToggleState()
        {
            if (_isMoveFinished == false) return;

            if (_state == State.ON)
            {
                _state = State.OFF;
                ScaleToTarget(this.transform, _offScale, 0.5f, ()=>
                {
                    _childSR.sortingOrder = 99;
                });
            }
            else
            {
                _state = State.ON;
                ScaleToTarget(this.transform, _onScale, 0.5f, null);
            }

            OnChangeState?.Invoke(this);
        }

       

        public void ScaleToTarget(Transform objectTrans, Vector2 targetScale, float animationDuration, System.Action OnFinished)
        {
            StartCoroutine(Scale(objectTrans, targetScale, animationDuration, OnFinished));
        }

        private IEnumerator Scale(Transform objectTrans, Vector2 targetScale, float animationDuration, System.Action OnFinished)
        {
            _isMoveFinished = false;
            Vector2 startScale = objectTrans.localScale;
            float elapsedTime = 0f;

            while (elapsedTime < animationDuration)
            {
                // Calculate the progress of the animation (a value between 0 and 1)
                float progress = elapsedTime / animationDuration;

                // Interpolate the current scale values towards the targetScale
                Vector2 currentScale = Vector2.Lerp(startScale, targetScale, progress);

                // Apply the new scale
                objectTrans.localScale = currentScale;

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Ensure the final scale is exactly the target scale to avoid floating-point imprecisions
            objectTrans.localScale = targetScale;
            _isMoveFinished = true;

            OnFinished?.Invoke();    
        }


        private void OnDestroy()
        {
            _detectMouseClick.OnClick -= ToggleState;
        }
    }
}
