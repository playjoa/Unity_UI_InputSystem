using UI_InputSystem.Base;
using UnityEngine;

public class DebugButtons : MonoBehaviour
{
    private void OnEnable()
    {
        UIInputSystem.ME.AddOnClickEvent(ButtonAction.OnClickEventTrigger, OnClickProcessor);
        UIInputSystem.ME.AddOnTouchEvent(ButtonAction.OnTouchEventTrigger, OnTouchProcessor);
    }

    private void OnDisable()
    {
        UIInputSystem.ME.RemoveOnClickEvent(ButtonAction.OnClickEventTrigger, OnClickProcessor);
        UIInputSystem.ME.RemoveOnTouchEvent(ButtonAction.OnTouchEventTrigger, OnTouchProcessor);
    }

    private void FixedUpdate()
    {
        if (UIInputSystem.ME.GetButton(ButtonAction.ClickTrigger))
            DebugText("Click Input: TRIGGERED!");

        if (UIInputSystem.ME.GetButton(ButtonAction.HoldTrigger))
            DebugText("Holding Input: TRIGGERED!");

        if (UIInputSystem.ME.GetButton(ButtonAction.TouchTrigger))
            DebugText("Touch Input: TRIGGERED!");
    }
    
    private void OnClickProcessor()
    {
        DebugText("Triggered OnClickEvent!");
    }

    private void OnTouchProcessor()
    {
        DebugText("Triggered OnTouchEvent!");
    }
    
    private void DebugText(string textToDebug)
    {
        Debug.Log(textToDebug);
    }
}