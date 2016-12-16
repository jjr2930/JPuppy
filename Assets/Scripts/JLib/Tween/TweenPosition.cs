using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JLib
{
    [AddComponentMenu("JTween/TweenPosition")]
    public class TweenPosition : Tween
    {
        [SerializeField]
        Vector3 from = Vector3.zero;

        [SerializeField]
        Vector3 to = Vector3.zero;

        protected override void OnOnEnable()
        {
            transform.position = from;
        }

        protected override void OnTweenUpdate()
        {
            Vector3 targetPosition = Vector3.Lerp(from, to, normalTime * curveValue);
            Debug.Log( normalTime * curveValue );
            transform.position = targetPosition;
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
}
