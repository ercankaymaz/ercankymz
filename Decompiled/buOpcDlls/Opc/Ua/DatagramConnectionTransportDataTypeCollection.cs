using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDatagramConnectionTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DatagramConnectionTransportDataType")]
[ComVisible(true)]
public class DatagramConnectionTransportDataTypeCollection : List<DatagramConnectionTransportDataType>, ICloneable
{
	public DatagramConnectionTransportDataTypeCollection()
	{
	}

	public DatagramConnectionTransportDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public DatagramConnectionTransportDataTypeCollection(IEnumerable<DatagramConnectionTransportDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator DatagramConnectionTransportDataTypeCollection(DatagramConnectionTransportDataType[] values)
	{
		if (values != null)
		{
			return new DatagramConnectionTransportDataTypeCollection(values);
		}
		return new DatagramConnectionTransportDataTypeCollection();
	}

	public static explicit operator DatagramConnectionTransportDataType[](DatagramConnectionTransportDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DatagramConnectionTransportDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DatagramConnectionTransportDataTypeCollection datagramConnectionTransportDataTypeCollection = new DatagramConnectionTransportDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			datagramConnectionTransportDataTypeCollection.Add((DatagramConnectionTransportDataType)Utils.Clone(base[i]));
		}
		return datagramConnectionTransportDataTypeCollection;
	}
}
