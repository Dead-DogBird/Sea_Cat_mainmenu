using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class D9Extension
{
    public static float Abs(this float num)
    {
        return num > 0 ? num : -num;
    }

    public static float Pow2(this float num)
    {
        return num * num;
    }

    public static int Abs(this int num)
    {
        return num > 0 ? num : -num;
    }

    public static decimal Abs(this decimal num)
    {
        return num > 0 ? num : -num;
    }

    public static float DegreePlus(this float num)
    {
        if (num > 0)
            return num >= 360 ? 360 - num : num;
        else
            return (360 - num);
    }

    ///<summary>벡터의 각도(degree)를 알려줍니다</summary>
    public static float Direction(this Vector2 pos)
    {
        float angle = (float)Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        if (angle < 0f)
            angle += 360f;
        return angle;
    }

    ///<summary>겜메 Length_x,y</summary>
    public static Vector2 DegreeToVector2(this float angle)
    {
        //반전화
        angle = -(angle - 90);

        if (angle < 0f)
            angle += 360f;

        return new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
    }
}
