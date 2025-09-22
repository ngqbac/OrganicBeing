using System;
using OrganicBeing.Core;
using UnityEngine;

namespace OrganicBeing.Integration.Unity
{
    public abstract class MonoOrganic: MonoBehaviour, IOrganic
    {
        protected virtual void Awake() => Grow();

        public bool IsReady { get; set; }
        public void Grow()
        {
            if (IsReady) return;
            OnGrow();
            IsReady = true;
        }
        
        protected abstract void OnGrow();
        
        protected void WhenReady(Action action)
        {
            if (!IsReady) Grow();
            action();
        }

        protected T WhenReady<T>(Func<T> func)
        {
            if (!IsReady) Grow();
            return func();
        }

        public virtual void OnRecycle() { }
    }
}