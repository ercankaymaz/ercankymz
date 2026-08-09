using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfServerOnNetwork", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ServerOnNetwork")]
[ComVisible(true)]
public class ServerOnNetworkCollection : List<ServerOnNetwork>, ICloneable
{
	public ServerOnNetworkCollection()
	{
	}

	public ServerOnNetworkCollection(int capacity)
		: base(capacity)
	{
	}

	public ServerOnNetworkCollection(IEnumerable<ServerOnNetwork> collection)
		: base(collection)
	{
	}

	public static implicit operator ServerOnNetworkCollection(ServerOnNetwork[] values)
	{
		if (values != null)
		{
			return new ServerOnNetworkCollection(values);
		}
		return new ServerOnNetworkCollection();
	}

	public static explicit operator ServerOnNetwork[](ServerOnNetworkCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ServerOnNetworkCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ServerOnNetworkCollection serverOnNetworkCollection = new ServerOnNetworkCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			serverOnNetworkCollection.Add((ServerOnNetwork)Utils.Clone(base[i]));
		}
		return serverOnNetworkCollection;
	}
}
