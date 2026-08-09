using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum AccessLevelType : byte
{
	[EnumMember(Value = "None_0")]
	None = 0,
	[EnumMember(Value = "CurrentRead_1")]
	CurrentRead = 1,
	[EnumMember(Value = "CurrentWrite_2")]
	CurrentWrite = 2,
	[EnumMember(Value = "HistoryRead_4")]
	HistoryRead = 4,
	[EnumMember(Value = "HistoryWrite_8")]
	HistoryWrite = 8,
	[EnumMember(Value = "SemanticChange_16")]
	SemanticChange = 0x10,
	[EnumMember(Value = "StatusWrite_32")]
	StatusWrite = 0x20,
	[EnumMember(Value = "TimestampWrite_64")]
	TimestampWrite = 0x40
}
