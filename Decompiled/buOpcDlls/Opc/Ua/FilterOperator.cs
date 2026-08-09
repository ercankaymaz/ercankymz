using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum FilterOperator
{
	[EnumMember(Value = "Equals_0")]
	Equals,
	[EnumMember(Value = "IsNull_1")]
	IsNull,
	[EnumMember(Value = "GreaterThan_2")]
	GreaterThan,
	[EnumMember(Value = "LessThan_3")]
	LessThan,
	[EnumMember(Value = "GreaterThanOrEqual_4")]
	GreaterThanOrEqual,
	[EnumMember(Value = "LessThanOrEqual_5")]
	LessThanOrEqual,
	[EnumMember(Value = "Like_6")]
	Like,
	[EnumMember(Value = "Not_7")]
	Not,
	[EnumMember(Value = "Between_8")]
	Between,
	[EnumMember(Value = "InList_9")]
	InList,
	[EnumMember(Value = "And_10")]
	And,
	[EnumMember(Value = "Or_11")]
	Or,
	[EnumMember(Value = "Cast_12")]
	Cast,
	[EnumMember(Value = "InView_13")]
	InView,
	[EnumMember(Value = "OfType_14")]
	OfType,
	[EnumMember(Value = "RelatedTo_15")]
	RelatedTo,
	[EnumMember(Value = "BitwiseAnd_16")]
	BitwiseAnd,
	[EnumMember(Value = "BitwiseOr_17")]
	BitwiseOr
}
