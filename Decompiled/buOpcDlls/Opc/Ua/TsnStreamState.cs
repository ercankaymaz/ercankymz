using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum TsnStreamState
{
	[EnumMember(Value = "Disabled_0")]
	Disabled,
	[EnumMember(Value = "Configuring_1")]
	Configuring,
	[EnumMember(Value = "Ready_2")]
	Ready,
	[EnumMember(Value = "Operational_3")]
	Operational,
	[EnumMember(Value = "Error_4")]
	Error
}
