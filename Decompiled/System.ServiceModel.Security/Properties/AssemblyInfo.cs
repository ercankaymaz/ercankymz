using System;
using System.Diagnostics;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;

[assembly: AssemblyDefaultAlias("System.ServiceModel.Security")]
[assembly: AssemblyMetadata(".NETFrameworkAssembly", "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("System.ServiceModel.Security")]
[assembly: AssemblyFileVersion("4.1000.22.41602")]
[assembly: AssemblyInformationalVersion("3.4.0")]
[assembly: AssemblyProduct("Microsoft® .NET Core")]
[assembly: AssemblyTitle("System.ServiceModel.Security")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/dotnet/wcf")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyVersion("4.10.0.0")]
[assembly: TypeForwardedTo(typeof(IAuthorizationPolicy))]
[assembly: TypeForwardedTo(typeof(GenericXmlSecurityKeyIdentifierClause))]
[assembly: TypeForwardedTo(typeof(GenericXmlSecurityToken))]
[assembly: TypeForwardedTo(typeof(SecurityKeyType))]
[assembly: TypeForwardedTo(typeof(ISecurityCapabilities))]
[assembly: TypeForwardedTo(typeof(LocalClientSecuritySettings))]
[assembly: TypeForwardedTo(typeof(SecurityBindingElement))]
[assembly: TypeForwardedTo(typeof(SecurityHeaderLayout))]
[assembly: TypeForwardedTo(typeof(TransportSecurityBindingElement))]
[assembly: TypeForwardedTo(typeof(DnsEndpointIdentity))]
[assembly: TypeForwardedTo(typeof(MessageSecurityVersion))]
[assembly: TypeForwardedTo(typeof(BasicSecurityProfileVersion))]
[assembly: TypeForwardedTo(typeof(SecureConversationVersion))]
[assembly: TypeForwardedTo(typeof(SecurityAlgorithmSuite))]
[assembly: TypeForwardedTo(typeof(SecurityKeyEntropyMode))]
[assembly: TypeForwardedTo(typeof(SecurityPolicyVersion))]
[assembly: TypeForwardedTo(typeof(SecurityVersion))]
[assembly: TypeForwardedTo(typeof(BinarySecretSecurityToken))]
[assembly: TypeForwardedTo(typeof(IssuedSecurityTokenParameters))]
[assembly: TypeForwardedTo(typeof(SecureConversationSecurityTokenParameters))]
[assembly: TypeForwardedTo(typeof(SecurityTokenParameters))]
[assembly: TypeForwardedTo(typeof(ServiceModelSecurityTokenRequirement))]
[assembly: TypeForwardedTo(typeof(SupportingTokenParameters))]
[assembly: TypeForwardedTo(typeof(UserNameSecurityTokenParameters))]
[assembly: TypeForwardedTo(typeof(TrustVersion))]
[assembly: TypeForwardedTo(typeof(SpnEndpointIdentity))]
[assembly: TypeForwardedTo(typeof(UpnEndpointIdentity))]
[assembly: TypeForwardedTo(typeof(X509CertificateEndpointIdentity))]
