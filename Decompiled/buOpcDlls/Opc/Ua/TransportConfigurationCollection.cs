using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfTransportConfiguration", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "TransportConfiguration")]
[ComVisible(true)]
public class TransportConfigurationCollection : List<TransportConfiguration>
{
	public TransportConfigurationCollection()
	{
	}

	public TransportConfigurationCollection(IEnumerable<TransportConfiguration> collection)
		: base(collection)
	{
	}

	public TransportConfigurationCollection(int capacity)
		: base(capacity)
	{
	}
}
