using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfReverseConnectClientEndpoint", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "ClientEndpoint")]
[ComVisible(true)]
public class ReverseConnectClientEndpointCollection : List<ReverseConnectClientEndpoint>
{
	public ReverseConnectClientEndpointCollection()
	{
	}

	public ReverseConnectClientEndpointCollection(IEnumerable<ReverseConnectClientEndpoint> collection)
		: base(collection)
	{
	}

	public ReverseConnectClientEndpointCollection(int capacity)
		: base(capacity)
	{
	}
}
