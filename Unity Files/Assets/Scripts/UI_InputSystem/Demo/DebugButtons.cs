using UnityEngine;
using UI_Inputs.Enums;

public class DebugButtons : MonoBehaviour
{
    private void Update()
    {
        if (UI_InputSystem.ButtonValue(ButtonAction.Action1))
            DebugText("Click Input: TRIGGERED!");

        if (UI_InputSystem.ButtonValue(ButtonAction.Action2))
            DebugText("After click Input: TRIGGERED!");

        if (UI_InputSystem.ButtonValue(ButtonAction.Action3))
            DebugText("Holding Input: TRIGGERED!");

        if (UI_InputSystem.ButtonValue(ButtonAction.Action4))
            DebugText("Touch Input: TRIGGERED!");
    }

    void DebugText(string textToDebug)
    {
        Debug.Log(textToDebug);
    }
}