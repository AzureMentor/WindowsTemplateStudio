﻿//{[{
using Prism.Mvvm;
using System.Globalization;
using Param_RootNamespace.Services;
//}]}
namespace Param_RootNamespace
{
    public sealed partial class App : PrismUnityApplication
    {
        private async Task LaunchApplicationAsync(string page, object launchParam)
        {
//{[{
            await ThemeSelectorService.SetRequestedThemeAsync();
//}]}
        }

        protected override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            await base.OnInitializeAsync(args);
//{[{
            await ThemeSelectorService.InitializeAsync().ConfigureAwait(false);
//}]}
        }
    }
}
