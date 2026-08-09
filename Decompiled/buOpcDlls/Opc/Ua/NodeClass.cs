using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum NodeClass
{
	[EnumMember(Value = "Unspecified_0")]
	Unspecified = 0,
	[EnumMember(Value = "Object_1")]
	Object = 1,
	[EnumMember(Value = "Variable_2")]
	Variable = 2,
	[EnumMember(Value = "Method_4")]
	Method = 4,
	[EnumMember(Value = "ObjectType_8")]
	ObjectType = 8,
	[EnumMember(Value = "VariableType_16")]
	VariableType = 0x10,
	[EnumMember(Value = "ReferenceType_32")]
	ReferenceType = 0x20,
	[EnumMember(Value = "DataType_64")]
	DataType = 0x40,
	[EnumMember(Value = "View_128")]
	View = 0x80
}
