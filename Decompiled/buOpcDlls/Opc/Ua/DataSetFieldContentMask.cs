using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum DataSetFieldContentMask : uint
{
	[EnumMember(Value = "None_0")]
	None = 0u,
	[EnumMember(Value = "StatusCode_1")]
	StatusCode = 1u,
	[EnumMember(Value = "SourceTimestamp_2")]
	SourceTimestamp = 2u,
	[EnumMember(Value = "ServerTimestamp_4")]
	ServerTimestamp = 4u,
	[EnumMember(Value = "SourcePicoSeconds_8")]
	SourcePicoSeconds = 8u,
	[EnumMember(Value = "ServerPicoSeconds_16")]
	ServerPicoSeconds = 0x10u,
	[EnumMember(Value = "RawData_32")]
	RawData = 0x20u
}
