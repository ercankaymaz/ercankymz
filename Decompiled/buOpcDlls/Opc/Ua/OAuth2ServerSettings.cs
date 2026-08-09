using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class OAuth2ServerSettings
{
	[DataMember(Order = 1)]
	public string ApplicationUri { get; set; }

	[DataMember(Order = 2)]
	public string ResourceId { get; set; }

	[DataMember(Order = 3)]
	public StringCollection Scopes { get; set; }
}
