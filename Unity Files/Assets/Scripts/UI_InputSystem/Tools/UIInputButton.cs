using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UI_Inputs.Tools;
using UI_InputSystem.Base;

namespace UI_Inputs
{
    public class UIInputButton : UIInput<ButtonAction, bool>, IPointerDownHandler, IPointerUpHandler
    {
        [Header("---------Button Type---------------")]
        [SerializeField]
        private ButtonType buttonType = ButtonType.Click;

        [Header("---------Button Action-------------")]
        [SerializeField]
        private ButtonAction buttonAction = ButtonAction.Jump;
        
        public override bool InputDefaultValue => false;
        public override bool InputValue => isPressing;
        public override ButtonAction InputID => buttonAction;
        public event Action OnClick;
        public event Action OnTouch;

        private bool isPressing;

        private enum ButtonType
        {
            Click,
            Touch,
            Hold
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ProcessClick();
            OnTouch?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ProcessClick(false);
            OnClick?.Invoke();
        }

        private void ProcessClick(bool pressing = true)
        {
            switch (buttonType)
            {
                case ButtonType.Touch when pressing:
                    StartCoroutine(MakeAFrameClick());
                    break;
                case ButtonType.Hold:
                    isPressing = !isPressing;
                    break;
                case ButtonType.Click when !pressing:
                    StartCoroutine(MakeAFrameClick());
                    break;
            }
        }
        
        private IEnumerator MakeAFrameClick()
        {
            isPressing = true;
            yield return new WaitForFixedUpdate();
            isPressing = false;
        }

        private void OnDisable()
        {
            isPressing = false;
        }
    }
}