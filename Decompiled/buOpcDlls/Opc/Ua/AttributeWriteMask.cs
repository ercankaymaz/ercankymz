using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[Flags]
[ComVisible(true)]
public enum AttributeWriteMask : uint
{
	[EnumMember(Value = "None_0")]
	None = 0u,
	[EnumMember(Value = "AccessLevel_1")]
	AccessLevel = 1u,
	[EnumMember(Value = "ArrayDimensions_2")]
	ArrayDimensions = 2u,
	[EnumMember(Value = "BrowseName_4")]
	BrowseName = 4u,
	[EnumMember(Value = "ContainsNoLoops_8")]
	ContainsNoLoops = 8u,
	[EnumMember(Value = "DataType_16")]
	DataType = 0x10u,
	[EnumMember(Value = "Description_32")]
	Description = 0x20u,
	[EnumMember(Value = "DisplayName_64")]
	DisplayName = 0x40u,
	[EnumMember(Value = "EventNotifier_128")]
	EventNotifier = 0x80u,
	[EnumMember(Value = "Executable_256")]
	Executable = 0x100u,
	[EnumMember(Value = "Historizing_512")]
	Historizing = 0x200u,
	[EnumMember(Value = "InverseName_1024")]
	InverseName = 0x400u,
	[EnumMember(Value = "IsAbstract_2048")]
	IsAbstract = 0x800u,
	[EnumMember(Value = "MinimumSamplingInterval_4096")]
	MinimumSamplingInterval = 0x1000u,
	[EnumMember(Value = "NodeClass_8192")]
	NodeClass = 0x2000u,
	[EnumMember(Value = "NodeId_16384")]
	NodeId = 0x4000u,
	[EnumMember(Value = "Symmetric_32768")]
	Symmetric = 0x8000u,
	[EnumMember(Value = "UserAccessLevel_65536")]
	UserAccessLevel = 0x10000u,
	[EnumMember(Value = "UserExecutable_131072")]
	UserExecutable = 0x20000u,
	[EnumMember(Value = "UserWriteMask_262144")]
	UserWriteMask = 0x40000u,
	[EnumMember(Value = "ValueRank_524288")]
	ValueRank = 0x80000u,
	[EnumMember(Value = "WriteMask_1048576")]
	WriteMask = 0x100000u,
	[EnumMember(Value = "ValueForVariableType_2097152")]
	ValueForVariableType = 0x200000u,
	[EnumMember(Value = "DataTypeDefinition_4194304")]
	DataTypeDefinition = 0x400000u,
	[EnumMember(Value = "RolePermissions_8388608")]
	RolePermissions = 0x800000u,
	[EnumMember(Value = "AccessRestrictions_16777216")]
	AccessRestrictions = 0x1000000u,
	[EnumMember(Value = "AccessLevelEx_33554432")]
	AccessLevelEx = 0x2000000u
}
