
using System;
using UnityEngine;
namespace JLib
{
    public class TweenColor : Tween
    {
        [SerializeField]
        Color from = Color.white;

        [SerializeField]
        Color to = Color.white;

        new Renderer renderer = null;
        protected override void OnAwake()
        {
            renderer = GetComponent<Renderer>();
        }
        protected override void OnOnEnable()
        {
            renderer.material.color = from;
        }

        protected override void OnTweenUpdate()
        {
            Color targetColor = Color.Lerp(from, to, normalTime * curveValue);
            renderer.material.color = targetColor;
        }

        public override void LoopMethod()
        {
            duringTime = 0;
            startTime = JTime.Time;
        }

        public override void PingpongMethod()
        {
            var temp = from;
            from = to;
            to = temp;
        }


        
    }
}
