using System.Collections.Generic;
using OrganicBeing.Utilities;

namespace OrganicBeing
{
    public class OrganicPool<T> where T : OrganicObject, new()
    {
        private readonly Stack<T> _pool = new();
        private readonly int _maxSize;

        public OrganicPool(int? overrideMaxSize = null)
        {
            _maxSize = overrideMaxSize ?? OrganicSettings.MaxPoolSize;
            OrganicLog.Info($"OrganicPool<{typeof(T).Name}> initialized with max size {_maxSize}");
        }

        public T Get()
        {
            var instance = _pool.Count > 0 ? _pool.Pop() : new T();
            instance.IsReady = false;
            return instance;
        }

        public void Return(T instance)
        {
            instance.OnRecycle();
            instance.IsReady = false;

            if (_pool.Count < _maxSize)
            {
                _pool.Push(instance);
            }
            else
            {
                OrganicLog.Warn($"OrganicPool<{typeof(T).Name}> reached max size ({_maxSize}). Instance discarded.");
            }
        }

        public void Clear() => _pool.Clear();
    }
}