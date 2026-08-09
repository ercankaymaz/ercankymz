using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfBrokerConnectionTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrokerConnectionTransportDataType")]
[ComVisible(true)]
public class BrokerConnectionTransportDataTypeCollection : List<BrokerConnectionTransportDataType>, ICloneable
{
	public BrokerConnectionTransportDataTypeCollection()
	{
	}

	public BrokerConnectionTransportDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public BrokerConnectionTransportDataTypeCollection(IEnumerable<BrokerConnectionTransportDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator BrokerConnectionTransportDataTypeCollection(BrokerConnectionTransportDataType[] values)
	{
		if (values != null)
		{
			return new BrokerConnectionTransportDataTypeCollection(values);
		}
		return new BrokerConnectionTransportDataTypeCollection();
	}

	public static explicit operator BrokerConnectionTransportDataType[](BrokerConnectionTransportDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (BrokerConnectionTransportDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrokerConnectionTransportDataTypeCollection brokerConnectionTransportDataTypeCollection = new BrokerConnectionTransportDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			brokerConnectionTransportDataTypeCollection.Add((BrokerConnectionTransportDataType)Utils.Clone(base[i]));
		}
		return brokerConnectionTransportDataTypeCollection;
	}
}
