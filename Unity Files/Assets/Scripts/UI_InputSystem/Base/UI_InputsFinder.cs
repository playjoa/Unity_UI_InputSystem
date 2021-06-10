using System.Collections.Generic;
using UnityEngine;
using UI_Inputs.Enums;

namespace UI_Inputs
{
    public static class UI_InputsFinder
    {
        public static Dictionary<ButtonAction, UI_InputButton> GetButtonDictionary()
        {
            Dictionary<ButtonAction, UI_InputButton> newUI_Buttons;

            UI_InputButton[] availableButtons = GetObjectsOfTypeUI_Button();
            newUI_Buttons = new Dictionary<ButtonAction, UI_InputButton>();

            foreach (UI_InputButton button in availableButtons)
            {
                if (!newUI_Buttons.ContainsKey(button.idButton))
                    newUI_Buttons.Add(button.idButton, button);
            }

            return newUI_Buttons;
        }

        public static Dictionary<JoyStickAction, UI_InputJoystick> GetJoystickDictionary()
        {
            Dictionary<JoyStickAction, UI_InputJoystick> newUI_Joysticks;

            UI_InputJoystick[] availableJoysticks = GetObjectsOfTypeUI_Joystick();
            newUI_Joysticks = new Dictionary<JoyStickAction, UI_InputJoystick>();

            foreach (UI_InputJoystick joystick in availableJoysticks)
            {
                if (!newUI_Joysticks.ContainsKey(joystick.idJoystick))
                    newUI_Joysticks.Add(joystick.idJoystick, joystick);
            }

            return newUI_Joysticks;
        }

        static UI_InputButton[] GetObjectsOfTypeUI_Button()
        {
            return Resources.FindObjectsOfTypeAll<UI_InputButton>();
        }

        static UI_InputJoystick[] GetObjectsOfTypeUI_Joystick()
        {
            return Resources.FindObjectsOfTypeAll<UI_InputJoystick>();
        }
    }
}