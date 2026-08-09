using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDatagramWriterGroupTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DatagramWriterGroupTransportDataType")]
[ComVisible(true)]
public class DatagramWriterGroupTransportDataTypeCollection : List<DatagramWriterGroupTransportDataType>, ICloneable
{
	public DatagramWriterGroupTransportDataTypeCollection()
	{
	}

	public DatagramWriterGroupTransportDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public DatagramWriterGroupTransportDataTypeCollection(IEnumerable<DatagramWriterGroupTransportDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator DatagramWriterGroupTransportDataTypeCollection(DatagramWriterGroupTransportDataType[] values)
	{
		if (values != null)
		{
			return new DatagramWriterGroupTransportDataTypeCollection(values);
		}
		return new DatagramWriterGroupTransportDataTypeCollection();
	}

	public static explicit operator DatagramWriterGroupTransportDataType[](DatagramWriterGroupTransportDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DatagramWriterGroupTransportDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DatagramWriterGroupTransportDataTypeCollection datagramWriterGroupTransportDataTypeCollection = new DatagramWriterGroupTransportDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			datagramWriterGroupTransportDataTypeCollection.Add((DatagramWriterGroupTransportDataType)Utils.Clone(base[i]));
		}
		return datagramWriterGroupTransportDataTypeCollection;
	}
}
