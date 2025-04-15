using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GameState
{
    public static Color currentColor = Color.red;
    public static bool hasSwitched = false;

    public static Color GetOppositeColor()
    {
        return (currentColor == Color.red) ? Color.blue : Color.red;
    }

    public static void ToggleColor()
    {
        currentColor = GetOppositeColor();
        hasSwitched = true;
    }

    public static void ResetSwitch()
    {
        hasSwitched = false;
    }
}
