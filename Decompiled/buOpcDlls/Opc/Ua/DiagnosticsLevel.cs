using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum DiagnosticsLevel
{
	[EnumMember(Value = "Basic_0")]
	Basic,
	[EnumMember(Value = "Advanced_1")]
	Advanced,
	[EnumMember(Value = "Info_2")]
	Info,
	[EnumMember(Value = "Log_3")]
	Log,
	[EnumMember(Value = "Debug_4")]
	Debug
}
