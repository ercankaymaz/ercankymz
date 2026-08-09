using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum IdType
{
	[EnumMember(Value = "Numeric_0")]
	Numeric,
	[EnumMember(Value = "String_1")]
	String,
	[EnumMember(Value = "Guid_2")]
	Guid,
	[EnumMember(Value = "Opaque_3")]
	Opaque
}
