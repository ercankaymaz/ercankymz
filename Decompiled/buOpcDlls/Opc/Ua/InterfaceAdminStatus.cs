using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum InterfaceAdminStatus
{
	[EnumMember(Value = "Up_0")]
	Up,
	[EnumMember(Value = "Down_1")]
	Down,
	[EnumMember(Value = "Testing_2")]
	Testing
}
