using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfConnectionTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ConnectionTransportDataType")]
[ComVisible(true)]
public class ConnectionTransportDataTypeCollection : List<ConnectionTransportDataType>, ICloneable
{
	public ConnectionTransportDataTypeCollection()
	{
	}

	public ConnectionTransportDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public ConnectionTransportDataTypeCollection(IEnumerable<ConnectionTransportDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator ConnectionTransportDataTypeCollection(ConnectionTransportDataType[] values)
	{
		if (values != null)
		{
			return new ConnectionTransportDataTypeCollection(values);
		}
		return new ConnectionTransportDataTypeCollection();
	}

	public static explicit operator ConnectionTransportDataType[](ConnectionTransportDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ConnectionTransportDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ConnectionTransportDataTypeCollection connectionTransportDataTypeCollection = new ConnectionTransportDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			connectionTransportDataTypeCollection.Add((ConnectionTransportDataType)Utils.Clone(base[i]));
		}
		return connectionTransportDataTypeCollection;
	}
}
