using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum IdentityCriteriaType
{
	[EnumMember(Value = "UserName_1")]
	UserName = 1,
	[EnumMember(Value = "Thumbprint_2")]
	Thumbprint,
	[EnumMember(Value = "Role_3")]
	Role,
	[EnumMember(Value = "GroupId_4")]
	GroupId,
	[EnumMember(Value = "Anonymous_5")]
	Anonymous,
	[EnumMember(Value = "AuthenticatedUser_6")]
	AuthenticatedUser,
	[EnumMember(Value = "Application_7")]
	Application
}
