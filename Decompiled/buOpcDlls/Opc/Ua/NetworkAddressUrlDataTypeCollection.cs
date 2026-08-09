using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfNetworkAddressUrlDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NetworkAddressUrlDataType")]
[ComVisible(true)]
public class NetworkAddressUrlDataTypeCollection : List<NetworkAddressUrlDataType>, ICloneable
{
	public NetworkAddressUrlDataTypeCollection()
	{
	}

	public NetworkAddressUrlDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public NetworkAddressUrlDataTypeCollection(IEnumerable<NetworkAddressUrlDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator NetworkAddressUrlDataTypeCollection(NetworkAddressUrlDataType[] values)
	{
		if (values != null)
		{
			return new NetworkAddressUrlDataTypeCollection(values);
		}
		return new NetworkAddressUrlDataTypeCollection();
	}

	public static explicit operator NetworkAddressUrlDataType[](NetworkAddressUrlDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (NetworkAddressUrlDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NetworkAddressUrlDataTypeCollection networkAddressUrlDataTypeCollection = new NetworkAddressUrlDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			networkAddressUrlDataTypeCollection.Add((NetworkAddressUrlDataType)Utils.Clone(base[i]));
		}
		return networkAddressUrlDataTypeCollection;
	}
}
