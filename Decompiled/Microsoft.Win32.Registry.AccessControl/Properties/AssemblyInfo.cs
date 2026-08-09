using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.AccessControl;

[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyDefaultAlias("Microsoft.Win32.Registry.AccessControl")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Provides support for managing access and audit control lists for Microsoft.Win32.RegistryKey.\r\n\r\nCommonly Used Types:\r\nSystem.Security.AccessControl.RegistryAccessRule\r\nSystem.Security.AccessControl.RegistryAuditRule\r\nSystem.Security.AccessControl.RegistrySecurity")]
[assembly: AssemblyFileVersion("9.0.425.16305")]
[assembly: AssemblyInformationalVersion("9.0.4+f57e6dc747158ab7ade4e62a75a6750d16b771e8")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("Microsoft.Win32.Registry.AccessControl")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/runtime")]
[assembly: AssemblyVersion("9.0.0.4")]
[assembly: TypeForwardedTo(typeof(RegistryAccessRule))]
[assembly: TypeForwardedTo(typeof(RegistryAuditRule))]
[assembly: TypeForwardedTo(typeof(RegistrySecurity))]
[module: NullablePublicOnly(false)]
