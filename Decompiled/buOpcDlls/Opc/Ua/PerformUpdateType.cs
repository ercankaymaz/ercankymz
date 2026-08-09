using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum PerformUpdateType
{
	[EnumMember(Value = "Insert_1")]
	Insert = 1,
	[EnumMember(Value = "Replace_2")]
	Replace,
	[EnumMember(Value = "Update_3")]
	Update,
	[EnumMember(Value = "Remove_4")]
	Remove
}
