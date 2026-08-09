using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.ServiceProcess;

[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyDefaultAlias("System.ServiceProcess.ServiceController")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Provides the System.ServiceProcess.ServiceController class, which allows you to connect to a Windows service, manipulate it, or get information about it.\r\n\r\nCommonly Used Types:\r\nSystem.ServiceProcess.ServiceController\r\nSystem.ServiceProcess.ServiceControllerStatus\r\nSystem.ServiceProcess.ServiceType")]
[assembly: AssemblyFileVersion("9.0.425.16305")]
[assembly: AssemblyInformationalVersion("9.0.4+f57e6dc747158ab7ade4e62a75a6750d16b771e8")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("System.ServiceProcess.ServiceController")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/runtime")]
[assembly: AssemblyVersion("9.0.0.4")]
[assembly: TypeForwardedTo(typeof(PowerBroadcastStatus))]
[assembly: TypeForwardedTo(typeof(ServiceBase))]
[assembly: TypeForwardedTo(typeof(ServiceController))]
[assembly: TypeForwardedTo(typeof(ServiceControllerStatus))]
[assembly: TypeForwardedTo(typeof(ServiceProcessDescriptionAttribute))]
[assembly: TypeForwardedTo(typeof(ServiceStartMode))]
[assembly: TypeForwardedTo(typeof(ServiceType))]
[assembly: TypeForwardedTo(typeof(SessionChangeDescription))]
[assembly: TypeForwardedTo(typeof(SessionChangeReason))]
[assembly: TypeForwardedTo(typeof(System.ServiceProcess.TimeoutException))]
