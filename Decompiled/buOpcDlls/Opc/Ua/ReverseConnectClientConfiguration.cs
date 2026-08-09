using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ReverseConnectClientConfiguration
{
	[DataMember(Order = 10, IsRequired = false)]
	public ReverseConnectClientEndpointCollection ClientEndpoints { get; set; }

	[DataMember(Order = 20, IsRequired = false)]
	public int HoldTime { get; set; } = 15000;

	[DataMember(Order = 30, IsRequired = false)]
	public int WaitTimeout { get; set; } = 20000;

	public ReverseConnectClientConfiguration()
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
