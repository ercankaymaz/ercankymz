using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum PubSubState
{
	[EnumMember(Value = "Disabled_0")]
	Disabled,
	[EnumMember(Value = "Paused_1")]
	Paused,
	[EnumMember(Value = "Operational_2")]
	Operational,
	[EnumMember(Value = "Error_3")]
	Error,
	[EnumMember(Value = "PreOperational_4")]
	PreOperational
}
