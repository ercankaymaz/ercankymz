using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum EventNotifierType : byte
{
	[EnumMember(Value = "None_0")]
	None = 0,
	[EnumMember(Value = "SubscribeToEvents_1")]
	SubscribeToEvents = 1,
	[EnumMember(Value = "HistoryRead_4")]
	HistoryRead = 4,
	[EnumMember(Value = "HistoryWrite_8")]
	HistoryWrite = 8
}
