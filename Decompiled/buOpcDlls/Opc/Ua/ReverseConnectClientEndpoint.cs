using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ReverseConnectClientEndpoint
{
	[DataMember(Order = 1, IsRequired = false)]
	public string EndpointUrl { get; set; }

	public ReverseConnectClientEndpoint()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
	}
}
