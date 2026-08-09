using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum UserTokenType
{
	[EnumMember(Value = "Anonymous_0")]
	Anonymous,
	[EnumMember(Value = "UserName_1")]
	UserName,
	[EnumMember(Value = "Certificate_2")]
	Certificate,
	[EnumMember(Value = "IssuedToken_3")]
	IssuedToken
}
