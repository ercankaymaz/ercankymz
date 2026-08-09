using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum DeadbandType
{
	[EnumMember(Value = "None_0")]
	None,
	[EnumMember(Value = "Absolute_1")]
	Absolute,
	[EnumMember(Value = "Percent_2")]
	Percent
}
