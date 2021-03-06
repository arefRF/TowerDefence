using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools
{

    public static Direction ReverseDirection(Direction direction)
    {
        switch (direction) {
            case Direction.Down: return Direction.Up;
            case Direction.Up: return Direction.Down;
            case Direction.Right: return Direction.Left;
            case Direction.Left: return Direction.Right;
            default: return Direction.Up;
        }
    }
}
