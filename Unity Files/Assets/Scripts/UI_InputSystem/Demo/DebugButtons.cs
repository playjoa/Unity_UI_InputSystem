using UI_InputSystem.Base;
using UnityEngine;

public class DebugButtons : MonoBehaviour
{
    private void Update()
    {
        if (UIInputSystem.GetButton(ButtonAction.ClickTrigger))
            DebugText("Click Input: TRIGGERED!");

        if (UIInputSystem.GetButton(ButtonAction.HoldTrigger))
            DebugText("Holding Input: TRIGGERED!");

        if (UIInputSystem.GetButton(ButtonAction.TouchTrigger))
            DebugText("Touch Input: TRIGGERED!");
    }

    private void DebugText(string textToDebug)
    {
        Debug.Log(textToDebug);
    }
}