using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UI_Inputs.Enums;

namespace UI_Inputs
{
    public class UI_InputButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        [Header("---------Button Click Type---------")]
        [SerializeField]
        private ButtonType buttonType = ButtonType.ClickTrigger;

        [Header("---------Button Action-------------")]
        [SerializeField]
        private ButtonAction _buttonAction = ButtonAction.Jump;

        public bool isPressing { get; private set; } = false;

        public ButtonAction idButton => _buttonAction;

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
            if (buttonType == ButtonType.TouchTrigger)
                StartCoroutine(MakeAFrameClick());
        }

        void ProcessIfAfterClickTrigger()
        {
            if (buttonType == ButtonType.AfterClickTrigger)
                StartCoroutine(MakeAFrameClick());
        }

        void ProcessIfClickTrigger()
        {
            if (buttonType == ButtonType.ClickTrigger)
                StartCoroutine(MakeAFrameClick());
        }

        void ProcessIfHoldTrigger()
        {
            if (buttonType == ButtonType.HoldTrigger)
                isPressing = !isPressing;
        }

        private void OnDisable()
        {
            isPressing = false;
        }

        IEnumerator MakeAFrameClick()
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