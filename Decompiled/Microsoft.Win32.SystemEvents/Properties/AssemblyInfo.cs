using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Microsoft.Win32;

[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyDefaultAlias("Microsoft.Win32.SystemEvents")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Provides access to Windows system event notifications.\r\n\r\nCommonly Used Types:\r\nMicrosoft.Win32.SystemEvents")]
[assembly: AssemblyFileVersion("9.0.425.16305")]
[assembly: AssemblyInformationalVersion("9.0.4+f57e6dc747158ab7ade4e62a75a6750d16b771e8")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("Microsoft.Win32.SystemEvents")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/runtime")]
[assembly: AssemblyVersion("9.0.0.4")]
[assembly: TypeForwardedTo(typeof(PowerModeChangedEventArgs))]
[assembly: TypeForwardedTo(typeof(PowerModeChangedEventHandler))]
[assembly: TypeForwardedTo(typeof(PowerModes))]
[assembly: TypeForwardedTo(typeof(SessionEndedEventArgs))]
[assembly: TypeForwardedTo(typeof(SessionEndedEventHandler))]
[assembly: TypeForwardedTo(typeof(SessionEndingEventArgs))]
[assembly: TypeForwardedTo(typeof(SessionEndingEventHandler))]
[assembly: TypeForwardedTo(typeof(SessionEndReasons))]
[assembly: TypeForwardedTo(typeof(SessionSwitchEventArgs))]
[assembly: TypeForwardedTo(typeof(SessionSwitchEventHandler))]
[assembly: TypeForwardedTo(typeof(SessionSwitchReason))]
[assembly: TypeForwardedTo(typeof(SystemEvents))]
[assembly: TypeForwardedTo(typeof(TimerElapsedEventArgs))]
[assembly: TypeForwardedTo(typeof(TimerElapsedEventHandler))]
[assembly: TypeForwardedTo(typeof(UserPreferenceCategory))]
[assembly: TypeForwardedTo(typeof(UserPreferenceChangedEventArgs))]
[assembly: TypeForwardedTo(typeof(UserPreferenceChangedEventHandler))]
[assembly: TypeForwardedTo(typeof(UserPreferenceChangingEventArgs))]
[assembly: TypeForwardedTo(typeof(UserPreferenceChangingEventHandler))]
