using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButtons : MonoBehaviour
{
    private void Update()
    {
        if (UI_InputSystem.AfterClickInput)
            DebugText("After click Input: TRIGGERED!");

        if (UI_InputSystem.ClickInput)
            DebugText("Click Input: TRIGGERED!");

        if (UI_InputSystem.HoldClickInput)
            DebugText("Holding Input: TRIGGERED!");

        if (UI_InputSystem.TouchInput)
            DebugText("Touch Input: TRIGGERED!");
    }

    void DebugText(string textToDebug)
    {
        Debug.Log(textToDebug);
    }
}