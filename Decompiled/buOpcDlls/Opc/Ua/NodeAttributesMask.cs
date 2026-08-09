using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum NodeAttributesMask
{
	[EnumMember(Value = "None_0")]
	None = 0,
	[EnumMember(Value = "AccessLevel_1")]
	AccessLevel = 1,
	[EnumMember(Value = "ArrayDimensions_2")]
	ArrayDimensions = 2,
	[EnumMember(Value = "BrowseName_4")]
	BrowseName = 4,
	[EnumMember(Value = "ContainsNoLoops_8")]
	ContainsNoLoops = 8,
	[EnumMember(Value = "DataType_16")]
	DataType = 16,
	[EnumMember(Value = "Description_32")]
	Description = 32,
	[EnumMember(Value = "DisplayName_64")]
	DisplayName = 64,
	[EnumMember(Value = "EventNotifier_128")]
	EventNotifier = 128,
	[EnumMember(Value = "Executable_256")]
	Executable = 256,
	[EnumMember(Value = "Historizing_512")]
	Historizing = 512,
	[EnumMember(Value = "InverseName_1024")]
	InverseName = 1024,
	[EnumMember(Value = "IsAbstract_2048")]
	IsAbstract = 2048,
	[EnumMember(Value = "MinimumSamplingInterval_4096")]
	MinimumSamplingInterval = 4096,
	[EnumMember(Value = "NodeClass_8192")]
	NodeClass = 8192,
	[EnumMember(Value = "NodeId_16384")]
	NodeId = 16384,
	[EnumMember(Value = "Symmetric_32768")]
	Symmetric = 32768,
	[EnumMember(Value = "UserAccessLevel_65536")]
	UserAccessLevel = 65536,
	[EnumMember(Value = "UserExecutable_131072")]
	UserExecutable = 131072,
	[EnumMember(Value = "UserWriteMask_262144")]
	UserWriteMask = 262144,
	[EnumMember(Value = "ValueRank_524288")]
	ValueRank = 524288,
	[EnumMember(Value = "WriteMask_1048576")]
	WriteMask = 1048576,
	[EnumMember(Value = "Value_2097152")]
	Value = 2097152,
	[EnumMember(Value = "DataTypeDefinition_4194304")]
	DataTypeDefinition = 4194304,
	[EnumMember(Value = "RolePermissions_8388608")]
	RolePermissions = 8388608,
	[EnumMember(Value = "AccessRestrictions_16777216")]
	AccessRestrictions = 16777216,
	[EnumMember(Value = "All_33554431")]
	All = 33554431,
	[EnumMember(Value = "BaseNode_26501220")]
	BaseNode = 26501220,
	[EnumMember(Value = "Object_26501348")]
	Object = 26501348,
	[EnumMember(Value = "ObjectType_26503268")]
	ObjectType = 26503268,
	[EnumMember(Value = "Variable_26571383")]
	Variable = 26571383,
	[EnumMember(Value = "VariableType_28600438")]
	VariableType = 28600438,
	[EnumMember(Value = "Method_26632548")]
	Method = 26632548,
	[EnumMember(Value = "ReferenceType_26537060")]
	ReferenceType = 26537060,
	[EnumMember(Value = "View_26501356")]
	View = 26501356
}
