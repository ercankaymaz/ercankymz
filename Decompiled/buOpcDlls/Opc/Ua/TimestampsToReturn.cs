using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum TimestampsToReturn
{
	[EnumMember(Value = "Source_0")]
	Source,
	[EnumMember(Value = "Server_1")]
	Server,
	[EnumMember(Value = "Both_2")]
	Both,
	[EnumMember(Value = "Neither_3")]
	Neither,
	[EnumMember(Value = "Invalid_4")]
	Invalid
}
