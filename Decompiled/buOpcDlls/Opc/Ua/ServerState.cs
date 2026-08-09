using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum ServerState
{
	[EnumMember(Value = "Running_0")]
	Running,
	[EnumMember(Value = "Failed_1")]
	Failed,
	[EnumMember(Value = "NoConfiguration_2")]
	NoConfiguration,
	[EnumMember(Value = "Suspended_3")]
	Suspended,
	[EnumMember(Value = "Shutdown_4")]
	Shutdown,
	[EnumMember(Value = "Test_5")]
	Test,
	[EnumMember(Value = "CommunicationFault_6")]
	CommunicationFault,
	[EnumMember(Value = "Unknown_7")]
	Unknown
}
