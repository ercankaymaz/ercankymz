using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum JsonDataSetMessageContentMask : uint
{
	[EnumMember(Value = "None_0")]
	None = 0u,
	[EnumMember(Value = "DataSetWriterId_1")]
	DataSetWriterId = 1u,
	[EnumMember(Value = "MetaDataVersion_2")]
	MetaDataVersion = 2u,
	[EnumMember(Value = "SequenceNumber_4")]
	SequenceNumber = 4u,
	[EnumMember(Value = "Timestamp_8")]
	Timestamp = 8u,
	[EnumMember(Value = "Status_16")]
	Status = 0x10u,
	[EnumMember(Value = "MessageType_32")]
	MessageType = 0x20u
}
