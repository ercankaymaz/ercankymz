using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum AccessLevelExType : uint
{
	[EnumMember(Value = "None_0")]
	None = 0u,
	[EnumMember(Value = "CurrentRead_1")]
	CurrentRead = 1u,
	[EnumMember(Value = "CurrentWrite_2")]
	CurrentWrite = 2u,
	[EnumMember(Value = "HistoryRead_4")]
	HistoryRead = 4u,
	[EnumMember(Value = "HistoryWrite_8")]
	HistoryWrite = 8u,
	[EnumMember(Value = "SemanticChange_16")]
	SemanticChange = 0x10u,
	[EnumMember(Value = "StatusWrite_32")]
	StatusWrite = 0x20u,
	[EnumMember(Value = "TimestampWrite_64")]
	TimestampWrite = 0x40u,
	[EnumMember(Value = "NonatomicRead_256")]
	NonatomicRead = 0x100u,
	[EnumMember(Value = "NonatomicWrite_512")]
	NonatomicWrite = 0x200u,
	[EnumMember(Value = "WriteFullArrayOnly_1024")]
	WriteFullArrayOnly = 0x400u,
	[EnumMember(Value = "NoSubDataTypes_2048")]
	NoSubDataTypes = 0x800u
}
