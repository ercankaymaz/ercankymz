using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum OpenFileMode
{
	[EnumMember(Value = "Read_1")]
	Read = 1,
	[EnumMember(Value = "Write_2")]
	Write = 2,
	[EnumMember(Value = "EraseExisting_4")]
	EraseExisting = 4,
	[EnumMember(Value = "Append_8")]
	Append = 8
}
