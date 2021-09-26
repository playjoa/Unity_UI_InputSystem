using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UI_Inputs.Tools;
using UI_InputSystem.Base;

namespace UI_Inputs
{
    public class UIInputButton : UIInput<ButtonAction>, IPointerDownHandler, IPointerUpHandler
    {
        [Header("---------Button Type---------")]
        [SerializeField]
        private ButtonType buttonType = ButtonType.Click;

        [Header("---------Button Action-------------")]
        [SerializeField]
        private ButtonAction buttonAction = ButtonAction.Jump;

        public bool IsPressing { get; private set; } = false;
        public override ButtonAction InputID => buttonAction;

        private enum ButtonType
        {
            Click,
            Touch,
            Hold
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ProcessClick();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ProcessClick(false);
        }

        private void ProcessClick(bool pressing = true)
        {
            switch (buttonType)
            {
                case ButtonType.Touch when pressing:
                    StartCoroutine(MakeAFrameClick());
                    break;
                case ButtonType.Hold:
                    IsPressing = !IsPressing;
                    break;
                case ButtonType.Click when !pressing:
                    StartCoroutine(MakeAFrameClick());
                    break;
            }
        }

        private void OnDisable()
        {
            IsPressing = false;
        }

        private IEnumerator MakeAFrameClick()
        {
            IsPressing = true;
            yield return new WaitForFixedUpdate();
            IsPressing = false;
        }
    }
}