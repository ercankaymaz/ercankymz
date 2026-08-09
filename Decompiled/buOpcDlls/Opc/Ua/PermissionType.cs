using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum PermissionType : uint
{
	[EnumMember(Value = "None_0")]
	None = 0u,
	[EnumMember(Value = "Browse_1")]
	Browse = 1u,
	[EnumMember(Value = "ReadRolePermissions_2")]
	ReadRolePermissions = 2u,
	[EnumMember(Value = "WriteAttribute_4")]
	WriteAttribute = 4u,
	[EnumMember(Value = "WriteRolePermissions_8")]
	WriteRolePermissions = 8u,
	[EnumMember(Value = "WriteHistorizing_16")]
	WriteHistorizing = 0x10u,
	[EnumMember(Value = "Read_32")]
	Read = 0x20u,
	[EnumMember(Value = "Write_64")]
	Write = 0x40u,
	[EnumMember(Value = "ReadHistory_128")]
	ReadHistory = 0x80u,
	[EnumMember(Value = "InsertHistory_256")]
	InsertHistory = 0x100u,
	[EnumMember(Value = "ModifyHistory_512")]
	ModifyHistory = 0x200u,
	[EnumMember(Value = "DeleteHistory_1024")]
	DeleteHistory = 0x400u,
	[EnumMember(Value = "ReceiveEvents_2048")]
	ReceiveEvents = 0x800u,
	[EnumMember(Value = "Call_4096")]
	Call = 0x1000u,
	[EnumMember(Value = "AddReference_8192")]
	AddReference = 0x2000u,
	[EnumMember(Value = "RemoveReference_16384")]
	RemoveReference = 0x4000u,
	[EnumMember(Value = "DeleteNode_32768")]
	DeleteNode = 0x8000u,
	[EnumMember(Value = "AddNode_65536")]
	AddNode = 0x10000u
}
