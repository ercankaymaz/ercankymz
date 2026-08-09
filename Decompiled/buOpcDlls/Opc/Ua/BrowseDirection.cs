using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum BrowseDirection
{
	[EnumMember(Value = "Forward_0")]
	Forward,
	[EnumMember(Value = "Inverse_1")]
	Inverse,
	[EnumMember(Value = "Both_2")]
	Both,
	[EnumMember(Value = "Invalid_3")]
	Invalid
}
