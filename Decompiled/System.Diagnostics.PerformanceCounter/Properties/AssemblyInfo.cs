using System;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;

[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyDefaultAlias("System.Diagnostics.PerformanceCounter")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Provides the System.Diagnostics.PerformanceCounter class, which allows access to Windows performance counters.\r\n\r\nCommonly Used Types:\r\nSystem.Diagnostics.PerformanceCounter")]
[assembly: AssemblyFileVersion("8.0.23.53103")]
[assembly: AssemblyInformationalVersion("8.0.0+5535e31a712343a63f5d7d796cd874e563e5ac14")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("System.Diagnostics.PerformanceCounter")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/runtime")]
[assembly: AssemblyVersion("8.0.0.0")]
[assembly: TypeForwardedTo(typeof(CounterCreationData))]
[assembly: TypeForwardedTo(typeof(CounterCreationDataCollection))]
[assembly: TypeForwardedTo(typeof(CounterSample))]
[assembly: TypeForwardedTo(typeof(CounterSampleCalculator))]
[assembly: TypeForwardedTo(typeof(ICollectData))]
[assembly: TypeForwardedTo(typeof(InstanceData))]
[assembly: TypeForwardedTo(typeof(InstanceDataCollection))]
[assembly: TypeForwardedTo(typeof(InstanceDataCollectionCollection))]
[assembly: TypeForwardedTo(typeof(PerformanceCounter))]
[assembly: TypeForwardedTo(typeof(PerformanceCounterCategory))]
[assembly: TypeForwardedTo(typeof(PerformanceCounterCategoryType))]
[assembly: TypeForwardedTo(typeof(PerformanceCounterInstanceLifetime))]
[assembly: TypeForwardedTo(typeof(PerformanceCounterManager))]
[assembly: TypeForwardedTo(typeof(PerformanceCounterType))]
[assembly: TypeForwardedTo(typeof(CounterData))]
[assembly: TypeForwardedTo(typeof(CounterSet))]
[assembly: TypeForwardedTo(typeof(CounterSetInstance))]
[assembly: TypeForwardedTo(typeof(CounterSetInstanceCounterDataSet))]
[assembly: TypeForwardedTo(typeof(CounterSetInstanceType))]
[assembly: TypeForwardedTo(typeof(CounterType))]
