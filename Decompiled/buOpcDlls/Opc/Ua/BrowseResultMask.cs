using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum BrowseResultMask
{
	[EnumMember(Value = "None_0")]
	None = 0,
	[EnumMember(Value = "ReferenceTypeId_1")]
	ReferenceTypeId = 1,
	[EnumMember(Value = "IsForward_2")]
	IsForward = 2,
	[EnumMember(Value = "NodeClass_4")]
	NodeClass = 4,
	[EnumMember(Value = "BrowseName_8")]
	BrowseName = 8,
	[EnumMember(Value = "DisplayName_16")]
	DisplayName = 16,
	[EnumMember(Value = "TypeDefinition_32")]
	TypeDefinition = 32,
	[EnumMember(Value = "All_63")]
	All = 63,
	[EnumMember(Value = "ReferenceTypeInfo_3")]
	ReferenceTypeInfo = 3,
	[EnumMember(Value = "TargetInfo_60")]
	TargetInfo = 60
}
