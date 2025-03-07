using System;
using System.Diagnostics;
using System.Reflection;
using System.Security;
using GalaxyBudsClient.Interface.Dialogs;
using GalaxyBudsClient.Utils.Interface.DynamicLocalization;
using Microsoft.Win32;

#pragma warning disable CA1416

namespace GalaxyBudsClient.Platform.Windows
{
    public class AutoStartHelper : IAutoStartHelper
    {
        public bool Enabled
        {
            get
            {
                try
                {
                    if (!PlatformUtils.IsWindows)
                    {
                        return false;
                    }
                    
                    RegistryKey? key =
                        Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
                    return key?.GetValue("Galaxy Buds Client", null) != null;
                }
                catch (SecurityException)
                {
                    return false;
                }
            } 
            set
            {
                try
                {
                    if (!PlatformUtils.IsWindows)
                    {
                        return;
                    }
                    
                    if (value)
                    {
                        var key =
                            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        key?.SetValue("Galaxy Buds Client",
                            "\"" + Process.GetCurrentProcess().MainModule?.FileName + "\" /StartMinimized");
                    }
                    else
                    {
                        var key =
                            Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                        key?.DeleteValue("Galaxy Buds Client");
                    }

                    return;
                }
                catch (UnauthorizedAccessException)
                {
                    goto NOTIFY_USER;
                }
                catch (SecurityException)
                {
                    goto NOTIFY_USER;
                }
                NOTIFY_USER:
                new MessageBox()
                {
                    Title = Loc.Resolve("error"),
                    Description = Loc.Resolve("settings_autostart_permission")
                }.ShowDialog(MainWindow.Instance);
            }
        }
    }
}