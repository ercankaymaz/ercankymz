using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfNetworkGroupDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NetworkGroupDataType")]
[ComVisible(true)]
public class NetworkGroupDataTypeCollection : List<NetworkGroupDataType>, ICloneable
{
	public NetworkGroupDataTypeCollection()
	{
	}

	public NetworkGroupDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public NetworkGroupDataTypeCollection(IEnumerable<NetworkGroupDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator NetworkGroupDataTypeCollection(NetworkGroupDataType[] values)
	{
		if (values != null)
		{
			return new NetworkGroupDataTypeCollection(values);
		}
		return new NetworkGroupDataTypeCollection();
	}

	public static explicit operator NetworkGroupDataType[](NetworkGroupDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (NetworkGroupDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NetworkGroupDataTypeCollection networkGroupDataTypeCollection = new NetworkGroupDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			networkGroupDataTypeCollection.Add((NetworkGroupDataType)Utils.Clone(base[i]));
		}
		return networkGroupDataTypeCollection;
	}
}
