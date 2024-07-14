using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EtchaScriptableObject", order = 1)]


public class EtchaScriptable : ScriptableObject
{
    public int xValue =635;
    public int yValue =270;
    public int zValue =270;

    public int xPrev =0;
    public int yPrev =0;
    public int zPrev =0;

    public int rValue=255;
    public int gValue=0;
    public int bValue=0;

    public int rPrev;
    public int gPrev;
    public int bPrev;


    public Color startColor;
    public Color endColor;

    public float lineWidth;
    public float timerDelay = 0.1f;
}
