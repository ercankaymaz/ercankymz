using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataSetWriterTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetWriterTransportDataType")]
[ComVisible(true)]
public class DataSetWriterTransportDataTypeCollection : List<DataSetWriterTransportDataType>, ICloneable
{
	public DataSetWriterTransportDataTypeCollection()
	{
	}

	public DataSetWriterTransportDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public DataSetWriterTransportDataTypeCollection(IEnumerable<DataSetWriterTransportDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator DataSetWriterTransportDataTypeCollection(DataSetWriterTransportDataType[] values)
	{
		if (values != null)
		{
			return new DataSetWriterTransportDataTypeCollection(values);
		}
		return new DataSetWriterTransportDataTypeCollection();
	}

	public static explicit operator DataSetWriterTransportDataType[](DataSetWriterTransportDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataSetWriterTransportDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetWriterTransportDataTypeCollection dataSetWriterTransportDataTypeCollection = new DataSetWriterTransportDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataSetWriterTransportDataTypeCollection.Add((DataSetWriterTransportDataType)Utils.Clone(base[i]));
		}
		return dataSetWriterTransportDataTypeCollection;
	}
}
