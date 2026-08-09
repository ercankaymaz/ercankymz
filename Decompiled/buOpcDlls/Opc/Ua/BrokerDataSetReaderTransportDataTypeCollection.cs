using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfBrokerDataSetReaderTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrokerDataSetReaderTransportDataType")]
[ComVisible(true)]
public class BrokerDataSetReaderTransportDataTypeCollection : List<BrokerDataSetReaderTransportDataType>, ICloneable
{
	public BrokerDataSetReaderTransportDataTypeCollection()
	{
	}

	public BrokerDataSetReaderTransportDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public BrokerDataSetReaderTransportDataTypeCollection(IEnumerable<BrokerDataSetReaderTransportDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator BrokerDataSetReaderTransportDataTypeCollection(BrokerDataSetReaderTransportDataType[] values)
	{
		if (values != null)
		{
			return new BrokerDataSetReaderTransportDataTypeCollection(values);
		}
		return new BrokerDataSetReaderTransportDataTypeCollection();
	}

	public static explicit operator BrokerDataSetReaderTransportDataType[](BrokerDataSetReaderTransportDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (BrokerDataSetReaderTransportDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrokerDataSetReaderTransportDataTypeCollection brokerDataSetReaderTransportDataTypeCollection = new BrokerDataSetReaderTransportDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			brokerDataSetReaderTransportDataTypeCollection.Add((BrokerDataSetReaderTransportDataType)Utils.Clone(base[i]));
		}
		return brokerDataSetReaderTransportDataTypeCollection;
	}
}
