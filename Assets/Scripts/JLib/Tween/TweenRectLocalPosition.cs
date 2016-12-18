using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace JLib
{
    [AddComponentMenu("JTween/TweenRectLocalPosition")]
    [RequireComponent(typeof(RectTransform))]
    public class TweenRectLocalPosition : Tween
    {
        [SerializeField]
        Vector3 from = Vector3.zero;

        [SerializeField]
        Vector3 to = Vector3.zero;

        bool isValidate = true;
        protected override void OnAwake()
        {
            if(null == rectTransform)
            {
                isValidate = false;
            }
        }

        protected override void OnOnEnable()
        {
            if (!isValidate)
            {
                Debug.LogError("TweenRectLocalPosition is not validation component , please addcomponent to gameobject, which have RectTransfrom");
                Debug.Break();                
            }
            duringTime = 0;
            startTime = JTime.Time;
            rectTransform.anchoredPosition = from;
        }

        protected override void OnTweenUpdate()
        {
            Vector3 targetPosition = Vector3.Lerp(from, to, normalTime * curveValue);
            rectTransform.anchoredPosition = targetPosition;
        }

        public override void PingpongMethod()
        {
            var temp = from;
            from = to;
            to = temp;
        }

        public override void LoopMethod()
        {
            duringTime = 0f;
            startTime = JTime.Time;
        }
    }
}
