using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    public static float RandomVelocity(float minV, float maxV)
    {
        float v = Random.Range(minV, maxV);
        // random pos or neg signal
        float k = Random.Range(0, 1) == 0 ? -1 : 1;

        return v * k;
    }

    public static float NumberConverter(float v, float minV, float maxV, float newMin, float newMax)
    {
        if(v < 0 && minV > 0 && maxV > 0)
        {
            minV = -minV;
            maxV = -maxV;
        }
        else if (v > 0 && minV < 0 && maxV < 0)
        {
            minV = -minV;
            maxV = -maxV;
        }

        float vel = (((v - minV) * (newMax - newMin)) / (maxV - minV)) + newMin;

        return vel;
    }

}
