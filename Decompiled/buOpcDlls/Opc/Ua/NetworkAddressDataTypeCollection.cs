using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfNetworkAddressDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NetworkAddressDataType")]
[ComVisible(true)]
public class NetworkAddressDataTypeCollection : List<NetworkAddressDataType>, ICloneable
{
	public NetworkAddressDataTypeCollection()
	{
	}

	public NetworkAddressDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public NetworkAddressDataTypeCollection(IEnumerable<NetworkAddressDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator NetworkAddressDataTypeCollection(NetworkAddressDataType[] values)
	{
		if (values != null)
		{
			return new NetworkAddressDataTypeCollection(values);
		}
		return new NetworkAddressDataTypeCollection();
	}

	public static explicit operator NetworkAddressDataType[](NetworkAddressDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (NetworkAddressDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NetworkAddressDataTypeCollection networkAddressDataTypeCollection = new NetworkAddressDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			networkAddressDataTypeCollection.Add((NetworkAddressDataType)Utils.Clone(base[i]));
		}
		return networkAddressDataTypeCollection;
	}
}
