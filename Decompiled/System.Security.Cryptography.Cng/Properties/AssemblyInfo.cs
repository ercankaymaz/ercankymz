using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Cryptography;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;

[assembly: CLSCompliant(true)]
[assembly: SupportedOSPlatform("windows")]
[assembly: AssemblyDefaultAlias("System.Security.Cryptography.Cng")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyMetadata(".NETFrameworkAssembly", "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("System.Security.Cryptography.Cng")]
[assembly: AssemblyFileVersion("5.0.20.51904")]
[assembly: AssemblyInformationalVersion("5.0.0+cf258a14b70ad9069470a108f13765e0e5988f51")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("System.Security.Cryptography.Cng")]
[assembly: AssemblyMetadata("RepositoryUrl", "git://github.com/dotnet/runtime")]
[assembly: AssemblyVersion("5.0.0.0")]
[assembly: TypeForwardedTo(typeof(SafeNCryptHandle))]
[assembly: TypeForwardedTo(typeof(SafeNCryptKeyHandle))]
[assembly: TypeForwardedTo(typeof(SafeNCryptProviderHandle))]
[assembly: TypeForwardedTo(typeof(SafeNCryptSecretHandle))]
[assembly: TypeForwardedTo(typeof(AesCng))]
[assembly: TypeForwardedTo(typeof(CngAlgorithm))]
[assembly: TypeForwardedTo(typeof(CngAlgorithmGroup))]
[assembly: TypeForwardedTo(typeof(CngExportPolicies))]
[assembly: TypeForwardedTo(typeof(CngKey))]
[assembly: TypeForwardedTo(typeof(CngKeyBlobFormat))]
[assembly: TypeForwardedTo(typeof(CngKeyCreationOptions))]
[assembly: TypeForwardedTo(typeof(CngKeyCreationParameters))]
[assembly: TypeForwardedTo(typeof(CngKeyHandleOpenOptions))]
[assembly: TypeForwardedTo(typeof(CngKeyOpenOptions))]
[assembly: TypeForwardedTo(typeof(CngKeyUsages))]
[assembly: TypeForwardedTo(typeof(CngProperty))]
[assembly: TypeForwardedTo(typeof(CngPropertyCollection))]
[assembly: TypeForwardedTo(typeof(CngPropertyOptions))]
[assembly: TypeForwardedTo(typeof(CngProvider))]
[assembly: TypeForwardedTo(typeof(CngUIPolicy))]
[assembly: TypeForwardedTo(typeof(CngUIProtectionLevels))]
[assembly: TypeForwardedTo(typeof(DSACng))]
[assembly: TypeForwardedTo(typeof(ECDiffieHellmanCng))]
[assembly: TypeForwardedTo(typeof(ECDiffieHellmanCngPublicKey))]
[assembly: TypeForwardedTo(typeof(ECDiffieHellmanKeyDerivationFunction))]
[assembly: TypeForwardedTo(typeof(ECDsaCng))]
[assembly: TypeForwardedTo(typeof(ECKeyXmlFormat))]
[assembly: TypeForwardedTo(typeof(RSACng))]
[assembly: TypeForwardedTo(typeof(TripleDESCng))]
