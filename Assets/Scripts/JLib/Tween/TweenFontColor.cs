using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using JLib;
using System;

public class TweenFontColor : Tween
{
    [SerializeField]
    Color from = Color.white;
    [SerializeField]
    Color to = Color.white;


    Text txt = null;

    // Use this for initialization
    protected override void OnAwake()
    {
        txt = GetComponent<Text>();
    }

    protected override void OnOnEnable()
    {
        txt.color = from;
    }

    protected override void OnTweenUpdate()
    {
        txt.color = Color.Lerp( from , to , normalTime * curveValue );
    }

    public override void LoopMethod()
    {
        duringTime = 0f;
        startTime = JTime.Time;
    }

    public override void PingpongMethod()
    {
        var temp = from;
        from = to;
        to = temp;
    }
}
