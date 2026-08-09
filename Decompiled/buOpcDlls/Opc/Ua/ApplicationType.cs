using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public enum ApplicationType
{
	[EnumMember(Value = "Server_0")]
	Server,
	[EnumMember(Value = "Client_1")]
	Client,
	[EnumMember(Value = "ClientAndServer_2")]
	ClientAndServer,
	[EnumMember(Value = "DiscoveryServer_3")]
	DiscoveryServer
}
