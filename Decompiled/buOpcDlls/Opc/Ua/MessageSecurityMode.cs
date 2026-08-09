using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum MessageSecurityMode
{
	[EnumMember(Value = "Invalid_0")]
	Invalid,
	[EnumMember(Value = "None_1")]
	None,
	[EnumMember(Value = "Sign_2")]
	Sign,
	[EnumMember(Value = "SignAndEncrypt_3")]
	SignAndEncrypt
}
