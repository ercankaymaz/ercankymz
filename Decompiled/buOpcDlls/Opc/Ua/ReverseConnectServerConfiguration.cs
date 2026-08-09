using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ReverseConnectServerConfiguration
{
	[DataMember(Order = 10)]
	public ReverseConnectClientCollection Clients { get; set; }

	[DataMember(Order = 20)]
	public int ConnectInterval { get; set; }

	[DataMember(Order = 30)]
	public int ConnectTimeout { get; set; }

	[DataMember(Order = 40)]
	public int RejectTimeout { get; set; }

	public ReverseConnectServerConfiguration()
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
		ConnectInterval = 15000;
		ConnectTimeout = 30000;
		RejectTimeout = 60000;
	}
}
