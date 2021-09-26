using System.Collections.Generic;
using UI_Inputs;
using UnityEngine;

namespace UI_InputSystem.Base
{
    public static class UIInputSystem
    {
        private static Dictionary<ButtonAction, UIInputButton> _uiButtonInputs;
        private static Dictionary<JoyStickAction, UIInputJoystick> _uiJoySticks;

        #region Initialize Area
        private static void PrepareValues()
        {
            CreateButtonDictionary();
            CreateJoystickDictionary();
        }

        private static void CreateButtonDictionary()
        {
            if (_uiButtonInputs != null)
                return;

            _uiButtonInputs = UIInputsFinder.GetAvailableInputs<ButtonAction, UIInputButton>();
        }

        private static void CreateJoystickDictionary()
        {
            if (_uiJoySticks != null)
                return;

            _uiJoySticks = UIInputsFinder.GetAvailableInputs<JoyStickAction, UIInputJoystick>();
        }
        #endregion

        #region Inputs Area
        private static bool ButtonPressProcessor(ButtonAction buttonToCheckPress)
        {
            PrepareValues();

            return _uiButtonInputs.ContainsKey(buttonToCheckPress) && _uiButtonInputs[buttonToCheckPress].IsPressing;
        }

        private static Vector2 JoyStickProcessor(JoyStickAction joyStickToCheckPress)
        {
            PrepareValues();

            return _uiJoySticks.ContainsKey(joyStickToCheckPress) ? _uiJoySticks[joyStickToCheckPress].JoystickDirection() : Vector2.zero;
        }

        public static Vector2 GetAxis(JoyStickAction joystickToChek) => JoyStickProcessor(joystickToChek);
        public static float GetAxisHorizontal(JoyStickAction joystickToChek) => JoyStickProcessor(joystickToChek).x;
        public static float GetAxisVertical(JoyStickAction joystickToChek) => JoyStickProcessor(joystickToChek).y;
        public static bool GetButton(ButtonAction buttonToCheck) => ButtonPressProcessor(buttonToCheck);
        #endregion
    }
}