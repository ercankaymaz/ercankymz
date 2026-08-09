using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfBrokerWriterGroupTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "BrokerWriterGroupTransportDataType")]
[ComVisible(true)]
public class BrokerWriterGroupTransportDataTypeCollection : List<BrokerWriterGroupTransportDataType>, ICloneable
{
	public BrokerWriterGroupTransportDataTypeCollection()
	{
	}

	public BrokerWriterGroupTransportDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public BrokerWriterGroupTransportDataTypeCollection(IEnumerable<BrokerWriterGroupTransportDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator BrokerWriterGroupTransportDataTypeCollection(BrokerWriterGroupTransportDataType[] values)
	{
		if (values != null)
		{
			return new BrokerWriterGroupTransportDataTypeCollection(values);
		}
		return new BrokerWriterGroupTransportDataTypeCollection();
	}

	public static explicit operator BrokerWriterGroupTransportDataType[](BrokerWriterGroupTransportDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (BrokerWriterGroupTransportDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrokerWriterGroupTransportDataTypeCollection brokerWriterGroupTransportDataTypeCollection = new BrokerWriterGroupTransportDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			brokerWriterGroupTransportDataTypeCollection.Add((BrokerWriterGroupTransportDataType)Utils.Clone(base[i]));
		}
		return brokerWriterGroupTransportDataTypeCollection;
	}
}
