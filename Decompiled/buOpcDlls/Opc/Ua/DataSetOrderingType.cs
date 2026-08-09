using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum DataSetOrderingType
{
	[EnumMember(Value = "Undefined_0")]
	Undefined,
	[EnumMember(Value = "AscendingWriterId_1")]
	AscendingWriterId,
	[EnumMember(Value = "AscendingWriterIdSingle_2")]
	AscendingWriterIdSingle
}
