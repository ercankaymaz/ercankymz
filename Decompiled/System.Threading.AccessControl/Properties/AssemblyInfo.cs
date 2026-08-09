using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.AccessControl;
using System.Security.Permissions;

[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyDefaultAlias("System.Threading.AccessControl")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Provides support for managing access and audit control lists for synchronization primitives.\r\n\r\nCommonly Used Types:\r\nSystem.Security.AccessControl.EventWaitHandleAccessRule\r\nSystem.Security.AccessControl.EventWaitHandleAuditRule\r\nSystem.Security.AccessControl.MutexAccessRule\r\nSystem.Security.AccessControl.MutexAuditRule\r\nSystem.Security.AccessControl.MutexSecurity\r\nSystem.Security.AccessControl.SemaphoreAccessRule\r\nSystem.Security.AccessControl.SemaphoreAuditRule\r\nSystem.Security.AccessControl.SemaphoreSecurity")]
[assembly: AssemblyFileVersion("9.0.425.16305")]
[assembly: AssemblyInformationalVersion("9.0.4+f57e6dc747158ab7ade4e62a75a6750d16b771e8")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("System.Threading.AccessControl")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/runtime")]
[assembly: AssemblyVersion("9.0.0.4")]
[assembly: TypeForwardedTo(typeof(EventWaitHandleAccessRule))]
[assembly: TypeForwardedTo(typeof(EventWaitHandleAuditRule))]
[assembly: TypeForwardedTo(typeof(EventWaitHandleRights))]
[assembly: TypeForwardedTo(typeof(EventWaitHandleSecurity))]
[assembly: TypeForwardedTo(typeof(MutexAccessRule))]
[assembly: TypeForwardedTo(typeof(MutexAuditRule))]
[assembly: TypeForwardedTo(typeof(MutexRights))]
[assembly: TypeForwardedTo(typeof(MutexSecurity))]
[assembly: TypeForwardedTo(typeof(SemaphoreAccessRule))]
[assembly: TypeForwardedTo(typeof(SemaphoreAuditRule))]
[assembly: TypeForwardedTo(typeof(SemaphoreRights))]
[assembly: TypeForwardedTo(typeof(SemaphoreSecurity))]
[module: NullablePublicOnly(false)]
