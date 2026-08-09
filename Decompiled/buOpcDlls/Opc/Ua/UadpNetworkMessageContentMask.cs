using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum UadpNetworkMessageContentMask : uint
{
	[EnumMember(Value = "None_0")]
	None = 0u,
	[EnumMember(Value = "PublisherId_1")]
	PublisherId = 1u,
	[EnumMember(Value = "GroupHeader_2")]
	GroupHeader = 2u,
	[EnumMember(Value = "WriterGroupId_4")]
	WriterGroupId = 4u,
	[EnumMember(Value = "GroupVersion_8")]
	GroupVersion = 8u,
	[EnumMember(Value = "NetworkMessageNumber_16")]
	NetworkMessageNumber = 0x10u,
	[EnumMember(Value = "SequenceNumber_32")]
	SequenceNumber = 0x20u,
	[EnumMember(Value = "PayloadHeader_64")]
	PayloadHeader = 0x40u,
	[EnumMember(Value = "Timestamp_128")]
	Timestamp = 0x80u,
	[EnumMember(Value = "PicoSeconds_256")]
	PicoSeconds = 0x100u,
	[EnumMember(Value = "DataSetClassId_512")]
	DataSetClassId = 0x200u,
	[EnumMember(Value = "PromotedFields_1024")]
	PromotedFields = 0x400u
}
