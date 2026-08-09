using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum JsonNetworkMessageContentMask : uint
{
	[EnumMember(Value = "None_0")]
	None = 0u,
	[EnumMember(Value = "NetworkMessageHeader_1")]
	NetworkMessageHeader = 1u,
	[EnumMember(Value = "DataSetMessageHeader_2")]
	DataSetMessageHeader = 2u,
	[EnumMember(Value = "SingleDataSetMessage_4")]
	SingleDataSetMessage = 4u,
	[EnumMember(Value = "PublisherId_8")]
	PublisherId = 8u,
	[EnumMember(Value = "DataSetClassId_16")]
	DataSetClassId = 0x10u,
	[EnumMember(Value = "ReplyTo_32")]
	ReplyTo = 0x20u
}
