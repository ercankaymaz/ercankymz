using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum DataSetFieldFlags : ushort
{
	[EnumMember(Value = "None_0")]
	None = 0,
	[EnumMember(Value = "PromotedField_1")]
	PromotedField = 1
}
