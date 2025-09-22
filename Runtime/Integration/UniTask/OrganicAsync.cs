#if ORGANIC_UNITASK
using System;
using Cysharp.Threading.Tasks;
using OrganicBeing.Core;

namespace OrganicBeing.Integration.Async
{
    public static class OrganicAsync
    {
        /// <summary>
        /// Awaits the organic object until it's fully grown (ready).
        /// </summary>
        public static async UniTask WhenReadyAsync(this IOrganic organic)
        {
            if (!organic.IsReady) organic.Grow();
            await UniTask.WaitUntil(() => organic.IsReady);
        }

        /// <summary>
        /// Runs a function once the organic object is ready.
        /// </summary>
        public static async UniTask<T> WhenReadyAsync<T>(this IOrganic organic, Func<T> func)
        {
            await organic.WhenReadyAsync();
            return func();
        }

        /// <summary>
        /// Runs an action once the organic object is ready.
        /// </summary>
        public static async UniTask WhenReadyAsync(this IOrganic organic, Action action)
        {
            await organic.WhenReadyAsync();
            action();
        }
    }
}
#endif