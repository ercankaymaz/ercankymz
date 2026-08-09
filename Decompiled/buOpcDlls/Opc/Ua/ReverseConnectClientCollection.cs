using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfReverseConnectClient", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "ReverseConnectClient")]
[ComVisible(true)]
public class ReverseConnectClientCollection : List<ReverseConnectClient>
{
	public ReverseConnectClientCollection()
	{
	}

	public ReverseConnectClientCollection(IEnumerable<ReverseConnectClient> collection)
		: base(collection)
	{
	}

	public ReverseConnectClientCollection(int capacity)
		: base(capacity)
	{
	}
}
