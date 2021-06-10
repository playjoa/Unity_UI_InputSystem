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

    public static Vector2 PlayerMovementDirection => JoyStickProcessor(JoyStickAction.Movement);

    public static float Camera_X_Movement => JoyStickProcessor(JoyStickAction.CameraLook).x;

    public static float Camera_Y_Movement => JoyStickProcessor(JoyStickAction.CameraLook).y;

    public static bool JumpInput => ButtonPressProcessor(ButtonAction.Jump);

    public static bool ClickInput => ButtonPressProcessor(ButtonAction.Action1);

    public static bool AfterClickInput => ButtonPressProcessor(ButtonAction.Action2);

    public static bool HoldClickInput => ButtonPressProcessor(ButtonAction.Action3);

    public static bool TouchInput => ButtonPressProcessor(ButtonAction.Action4);
    #endregion
}