using System.Collections.Generic;
using UnityEngine;
using UI_Inputs;

public static class UI_InputSystem
{
    private static Dictionary<string, UI_InputJoystick> UI_JoySticks;
    private static Dictionary<string, UI_InputButton> UI_Buttons;

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
    static bool ButtonPressProcessor(string buttonToCheckPress)
    {
        PrepareValues();

        if (UI_Buttons.ContainsKey(buttonToCheckPress))
            return UI_Buttons[buttonToCheckPress].isPressing;

        return false;
    }

    static Vector2 JoyStickProcessor(string joyStickToCheckPress)
    {
        PrepareValues();

        if (UI_JoySticks.ContainsKey(joyStickToCheckPress))
            return UI_JoySticks[joyStickToCheckPress].JoystickDirection();

        return Vector2.zero;
    }

    public static Vector2 PlayerMovementDirectio => JoyStickProcessor("movementJoystick");

    public static float Camera_X_Movement => JoyStickProcessor("cameraJoystick").x;

    public static float Camera_Y_Movement => JoyStickProcessor("cameraJoystick").y;

    public static bool JumpInput => ButtonPressProcessor("Jump");

    public static bool ClickInput => ButtonPressProcessor("clickTrigger");

    public static bool AfterClickInput => ButtonPressProcessor("afterTrigger");

    public static bool HoldClickInput => ButtonPressProcessor("holdTrigger");

    public static bool TouchInput => ButtonPressProcessor("touchTrigger");
    #endregion
}