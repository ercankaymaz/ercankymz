using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua.Security;

[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "ApplicationType", Namespace = "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd")]
[ComVisible(true)]
public enum ApplicationType
{
	[EnumMember]
	Server_0,
	[EnumMember]
	Client_1,
	[EnumMember]
	ClientAndServer_2,
	[EnumMember]
	DiscoveryServer_3
}
