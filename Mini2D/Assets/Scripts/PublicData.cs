using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PublicData
{
    public static Dictionary<Vector2, int> animationDirectionToIndex = new Dictionary<Vector2, int>()
    {
        {Vector2.zero, 0 },
        {Vector2.right, 1 },
        {Vector2.left, 1 },
        {Vector2.up, 2 }
    };
}
