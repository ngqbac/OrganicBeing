using System;

namespace OrganicBeing
{
    public abstract class OrganicObject : IOrganic
    {
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