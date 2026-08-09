using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfServerSecurityPolicy", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "ServerSecurityPolicy")]
[ComVisible(true)]
public class ServerSecurityPolicyCollection : List<ServerSecurityPolicy>
{
	public ServerSecurityPolicyCollection()
	{
	}

	public ServerSecurityPolicyCollection(IEnumerable<ServerSecurityPolicy> collection)
		: base(collection)
	{
	}

	public ServerSecurityPolicyCollection(int capacity)
		: base(capacity)
	{
	}
}
