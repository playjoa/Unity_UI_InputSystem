using System.Collections.Generic;
using UnityEngine;
using UI_Inputs;
using UI_Inputs.Enums;

public static class UI_InputSystem
{
    private static Dictionary<ButtonAction, UI_InputButton> UI_Buttons;
    private static Dictionary<JoyStickAction, UI_InputJoystick> UI_JoySticks;

    #region Initialize Area
    static void PrepareValues()
    {
        CreateButtonDictionary();
        CreateJoystickDictionary();
    }

    static void CreateButtonDictionary()
    {
        if (UI_Buttons != null)
            return;

        UI_Buttons = UI_InputsFinder.GetButtonDictionary();
    }

    static void CreateJoystickDictionary()
    {
        if (UI_JoySticks != null)
            return;

        UI_JoySticks = UI_InputsFinder.GetJoystickDictionary();
    }
    #endregion

    #region Inputs Area
    static bool ButtonPressProcessor(ButtonAction buttonToCheckPress)
    {
        PrepareValues();

        if (UI_Buttons.ContainsKey(buttonToCheckPress))
            return UI_Buttons[buttonToCheckPress].isPressing;

        return false;
    }

    static Vector2 JoyStickProcessor(JoyStickAction joyStickToCheckPress)
    {
        PrepareValues();

        if (UI_JoySticks.ContainsKey(joyStickToCheckPress))
            return UI_JoySticks[joyStickToCheckPress].JoystickDirection();

        return Vector2.zero;
    }

    public static Vector2 GetAxisValue(JoyStickAction joystickToChek) => JoyStickProcessor(joystickToChek);
    public static float GetAxisHorizontal(JoyStickAction joystickToChek) => JoyStickProcessor(joystickToChek).x;
    public static float GetAxisVertical(JoyStickAction joystickToChek) => JoyStickProcessor(joystickToChek).y;
    public static bool GetButton(ButtonAction buttonToCheck) => ButtonPressProcessor(buttonToCheck);
    #endregion
}