using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataSetReaderTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetReaderTransportDataType")]
[ComVisible(true)]
public class DataSetReaderTransportDataTypeCollection : List<DataSetReaderTransportDataType>, ICloneable
{
	public DataSetReaderTransportDataTypeCollection()
	{
	}

	public DataSetReaderTransportDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public DataSetReaderTransportDataTypeCollection(IEnumerable<DataSetReaderTransportDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator DataSetReaderTransportDataTypeCollection(DataSetReaderTransportDataType[] values)
	{
		if (values != null)
		{
			return new DataSetReaderTransportDataTypeCollection(values);
		}
		return new DataSetReaderTransportDataTypeCollection();
	}

	public static explicit operator DataSetReaderTransportDataType[](DataSetReaderTransportDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataSetReaderTransportDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetReaderTransportDataTypeCollection dataSetReaderTransportDataTypeCollection = new DataSetReaderTransportDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataSetReaderTransportDataTypeCollection.Add((DataSetReaderTransportDataType)Utils.Clone(base[i]));
		}
		return dataSetReaderTransportDataTypeCollection;
	}
}
