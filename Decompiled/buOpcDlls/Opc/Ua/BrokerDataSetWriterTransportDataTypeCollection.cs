using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfBrokerDataSetWriterTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrokerDataSetWriterTransportDataType")]
[ComVisible(true)]
public class BrokerDataSetWriterTransportDataTypeCollection : List<BrokerDataSetWriterTransportDataType>, ICloneable
{
	public BrokerDataSetWriterTransportDataTypeCollection()
	{
	}

	public BrokerDataSetWriterTransportDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public BrokerDataSetWriterTransportDataTypeCollection(IEnumerable<BrokerDataSetWriterTransportDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator BrokerDataSetWriterTransportDataTypeCollection(BrokerDataSetWriterTransportDataType[] values)
	{
		if (values != null)
		{
			return new BrokerDataSetWriterTransportDataTypeCollection(values);
		}
		return new BrokerDataSetWriterTransportDataTypeCollection();
	}

	public static explicit operator BrokerDataSetWriterTransportDataType[](BrokerDataSetWriterTransportDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (BrokerDataSetWriterTransportDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrokerDataSetWriterTransportDataTypeCollection brokerDataSetWriterTransportDataTypeCollection = new BrokerDataSetWriterTransportDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			brokerDataSetWriterTransportDataTypeCollection.Add((BrokerDataSetWriterTransportDataType)Utils.Clone(base[i]));
		}
		return brokerDataSetWriterTransportDataTypeCollection;
	}
}
