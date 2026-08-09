using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.Xml;
using System.Security.Permissions;

[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyDefaultAlias("System.Security.Cryptography.Pkcs")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.System32 | DllImportSearchPath.AssemblyDirectory)]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Provides support for PKCS and CMS algorithms.\r\n\r\nCommonly Used Types:\r\nSystem.Security.Cryptography.Pkcs.EnvelopedCms")]
[assembly: AssemblyFileVersion("9.0.425.16305")]
[assembly: AssemblyInformationalVersion("9.0.4+f57e6dc747158ab7ade4e62a75a6750d16b771e8")]
[assembly: AssemblyProduct("Microsoft® .NET")]
[assembly: AssemblyTitle("System.Security.Cryptography.Pkcs")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/runtime")]
[assembly: AssemblyVersion("9.0.0.4")]
[assembly: TypeForwardedTo(typeof(CryptographicAttributeObject))]
[assembly: TypeForwardedTo(typeof(CryptographicAttributeObjectCollection))]
[assembly: TypeForwardedTo(typeof(CryptographicAttributeObjectEnumerator))]
[assembly: TypeForwardedTo(typeof(AlgorithmIdentifier))]
[assembly: TypeForwardedTo(typeof(CmsRecipient))]
[assembly: TypeForwardedTo(typeof(CmsRecipientCollection))]
[assembly: TypeForwardedTo(typeof(CmsRecipientEnumerator))]
[assembly: TypeForwardedTo(typeof(CmsSigner))]
[assembly: TypeForwardedTo(typeof(ContentInfo))]
[assembly: TypeForwardedTo(typeof(EnvelopedCms))]
[assembly: TypeForwardedTo(typeof(KeyAgreeRecipientInfo))]
[assembly: TypeForwardedTo(typeof(KeyTransRecipientInfo))]
[assembly: TypeForwardedTo(typeof(Pkcs9AttributeObject))]
[assembly: TypeForwardedTo(typeof(Pkcs9ContentType))]
[assembly: TypeForwardedTo(typeof(Pkcs9DocumentDescription))]
[assembly: TypeForwardedTo(typeof(Pkcs9DocumentName))]
[assembly: TypeForwardedTo(typeof(Pkcs9MessageDigest))]
[assembly: TypeForwardedTo(typeof(Pkcs9SigningTime))]
[assembly: TypeForwardedTo(typeof(PublicKeyInfo))]
[assembly: TypeForwardedTo(typeof(RecipientInfo))]
[assembly: TypeForwardedTo(typeof(RecipientInfoCollection))]
[assembly: TypeForwardedTo(typeof(RecipientInfoEnumerator))]
[assembly: TypeForwardedTo(typeof(RecipientInfoType))]
[assembly: TypeForwardedTo(typeof(SignedCms))]
[assembly: TypeForwardedTo(typeof(SignerInfo))]
[assembly: TypeForwardedTo(typeof(SignerInfoCollection))]
[assembly: TypeForwardedTo(typeof(SignerInfoEnumerator))]
[assembly: TypeForwardedTo(typeof(SubjectIdentifier))]
[assembly: TypeForwardedTo(typeof(SubjectIdentifierOrKey))]
[assembly: TypeForwardedTo(typeof(SubjectIdentifierOrKeyType))]
[assembly: TypeForwardedTo(typeof(SubjectIdentifierType))]
[assembly: TypeForwardedTo(typeof(X509IssuerSerial))]
