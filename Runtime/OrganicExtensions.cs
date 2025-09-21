using System;

namespace OrganicBeing
{
    public static class OrganicExtensions
    {
        public static void WhenReady(this IOrganic self, Action action)
        {
            if (!self.IsReady) self.Grow();
            action();
        }

        public static T WhenReady<T>(this IOrganic self, Func<T> func)
        {
            if (!self.IsReady) self.Grow();
            return func();
        }

        public static bool EnsureGrown(this IOrganic self)
        {
            if (self.IsReady) return false;
            self.Grow();
            return true;
        }
    }
}