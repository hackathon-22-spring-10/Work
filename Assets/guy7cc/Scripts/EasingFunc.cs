using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingFunc
{
    public static float EaseInElastic(float t)
    {
        if (t <= 0) return 0;
        else if (t >= 1) return 1;
        else
        {
            float c = Mathf.PI * 2f / 3f;
            return -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * c);
        }
    }

    public static float EaseInBack(float t)
    {
        float c1 = 1.70158f;
        float c3 = c1 + 1;
        t = Mathf.Max(0, Mathf.Min(1, t));
        return c3 * t * t * t - c1 * t * t;
    }

    public static Vector2 Cycloid(float r, float theta)
    {
        return new Vector2(r * (theta - Mathf.Sin(theta)), r * (1 - Mathf.Cos(theta)));
    }
}
