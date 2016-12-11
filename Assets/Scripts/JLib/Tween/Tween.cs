using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
namespace JLib
{
    public abstract class Tween : JMonoBehaviour
    {

        [SerializeField]
        protected AnimationCurve curve;

        [SerializeField]
        protected TweenMode mode;

        [SerializeField]
        protected float duration = 0f;

        [SerializeField]
        protected float delay = 0f;
        
        [SerializeField]
        protected UnityEvent callback = null;

        protected float startTime = 0f;
        protected float normalTime = 0f;
        protected float duringTime = 0f;
        protected float curveValue = 0f;
        protected bool isEnabledBefore= false;
        
        void Awake()
        {
            TweenManager.AddTween(this);
            this.enabled = false;
            OnAwake();
        } 

        void OnEnable()
        {
            startTime = JTime.Time;
            duration = Mathf.Max(float.MinValue, duration);
            normalTime = 0f;
            OnOnEnable();
            isEnabledBefore = true;
        }
        public void UpdateTween()
        {
            duringTime += JTime.DeltaTime;
            normalTime = duringTime / duration;
            curveValue = curve.Evaluate(normalTime);
            OnTweenUpdate();

            if (duringTime >= duration)
            {
                this.enabled = false;
                callback.Invoke();
            }
            
        }


        private void OnDisable()
        {
            if(!isEnabledBefore)
            {
                return;
            }
            switch (mode)
            {
                case TweenMode.Normal:
                    duringTime = 0;
                    break;

                case TweenMode.Loop:
                    LoopMethod();
                    break;

                case TweenMode.Pingpong:
                    PingpongMethod();
                    break;
            }
        }

        public void Play()
        {
            enabled = true;
        }

        public void PlayFromBegin()
        {
            enabled = true;
            duringTime = 0f;
        }

        public abstract void LoopMethod();
        public abstract void PingpongMethod();
        protected abstract void OnOnEnable();        
        protected abstract void OnTweenUpdate();
        protected virtual void OnAwake() { }
    }
}
