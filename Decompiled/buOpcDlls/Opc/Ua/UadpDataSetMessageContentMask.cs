using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum UadpDataSetMessageContentMask : uint
{
	[EnumMember(Value = "None_0")]
	None = 0u,
	[EnumMember(Value = "Timestamp_1")]
	Timestamp = 1u,
	[EnumMember(Value = "PicoSeconds_2")]
	PicoSeconds = 2u,
	[EnumMember(Value = "Status_4")]
	Status = 4u,
	[EnumMember(Value = "MajorVersion_8")]
	MajorVersion = 8u,
	[EnumMember(Value = "MinorVersion_16")]
	MinorVersion = 0x10u,
	[EnumMember(Value = "SequenceNumber_32")]
	SequenceNumber = 0x20u
}
