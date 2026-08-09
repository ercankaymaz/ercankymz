using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ReverseConnectClient
{
	[DataMember(Order = 10)]
	public string EndpointUrl { get; set; }

	[DataMember(Order = 20)]
	public int Timeout { get; set; }

	[DataMember(Order = 30)]
	public int MaxSessionCount { get; set; }

	[DataMember(Order = 40)]
	public bool Enabled { get; set; } = true;

	public ReverseConnectClient()
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
		Enabled = true;
	}
}
