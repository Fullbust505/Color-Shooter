using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class GameState
{
    public static Color currentColor = Color.red;

    public static Color GetOppositeColor()
    {
        return (currentColor == Color.red) ? Color.blue : Color.red;
    }

    public static void ToggleColor()
    {
        currentColor = GetOppositeColor();
    }
}
