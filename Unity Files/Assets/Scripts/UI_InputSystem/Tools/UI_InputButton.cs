using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI_Inputs
{
    public class UI_InputButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private ButtonType thisButtonType = ButtonType.ClickTrigger;

        [SerializeField]
        private string _buttonID = "Jump";

        public bool isPressing { get; private set; } = false;

        public string idButton => _buttonID;

        public void OnPointerClick(PointerEventData eventData)
        {
            ProcessIfClickTrigger();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ProcessIfHoldTrigger();
            ProcessIfTouchTrigger();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ProcessIfHoldTrigger();
            ProcessIfAfterClickTrigger();
        }

        void ProcessIfTouchTrigger()
        {
            if (thisButtonType == ButtonType.TouchTrigger)
                StartCoroutine(MakeClick());
        }

        void ProcessIfAfterClickTrigger()
        {
            if (thisButtonType == ButtonType.AfterClickTrigger)
                StartCoroutine(MakeClick());
        }

        void ProcessIfClickTrigger()
        {
            if (thisButtonType == ButtonType.ClickTrigger)
                StartCoroutine(MakeClick());
        }

        void ProcessIfHoldTrigger()
        {
            if (thisButtonType == ButtonType.HoldTrigger)
                isPressing = !isPressing;
        }

        private void OnDisable()
        {
            isPressing = false;
        }

        IEnumerator MakeClick()
        {
            isPressing = true;
            yield return new WaitForEndOfFrame();
            isPressing = false;
        }
    }

    public enum ButtonType
    {
        ClickTrigger,
        TouchTrigger,
        HoldTrigger,
        AfterClickTrigger
    }
}