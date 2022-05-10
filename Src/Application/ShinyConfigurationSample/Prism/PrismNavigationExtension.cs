using System;
using System.Threading.Tasks;

namespace Prism.Navigation
{
    internal static class PrismNavigationExtension
    {
        internal static Task HandleNavigationErrorAsync(this Task<INavigationResult> navigationTask)
        {
            return HandleNavigationErrorAsync(navigationTask, null);
        }

        internal static async Task HandleNavigationErrorAsync(this Task<INavigationResult> navigationTask, Action<Exception> errorCallback)
        {
#if DEBUG
            System.Diagnostics.Debugger.Break();
#endif
            var result = await navigationTask;
            if (!result.Success)
                errorCallback?.Invoke(result.Exception);
        }
    }
}
