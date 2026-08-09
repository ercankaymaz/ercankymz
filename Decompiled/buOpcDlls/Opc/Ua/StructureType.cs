using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum StructureType
{
	[EnumMember(Value = "Structure_0")]
	Structure,
	[EnumMember(Value = "StructureWithOptionalFields_1")]
	StructureWithOptionalFields,
	[EnumMember(Value = "Union_2")]
	Union,
	[EnumMember(Value = "StructureWithSubtypedValues_3")]
	StructureWithSubtypedValues,
	[EnumMember(Value = "UnionWithSubtypedValues_4")]
	UnionWithSubtypedValues
}
