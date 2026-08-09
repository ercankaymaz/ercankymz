using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfServerRegistration", Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd", ItemName = "ServerRegistration")]
[ComVisible(true)]
public class ServerRegistrationCollection : List<ServerRegistration>
{
	public ServerRegistrationCollection()
	{
	}

	public ServerRegistrationCollection(IEnumerable<ServerRegistration> collection)
		: base(collection)
	{
	}

	public ServerRegistrationCollection(int capacity)
		: base(capacity)
	{
	}
}
