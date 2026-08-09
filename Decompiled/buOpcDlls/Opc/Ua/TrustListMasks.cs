using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum TrustListMasks
{
	[EnumMember(Value = "None_0")]
	None = 0,
	[EnumMember(Value = "TrustedCertificates_1")]
	TrustedCertificates = 1,
	[EnumMember(Value = "TrustedCrls_2")]
	TrustedCrls = 2,
	[EnumMember(Value = "IssuerCertificates_4")]
	IssuerCertificates = 4,
	[EnumMember(Value = "IssuerCrls_8")]
	IssuerCrls = 8,
	[EnumMember(Value = "All_15")]
	All = 15
}
