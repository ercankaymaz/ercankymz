using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataSetWriterMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetWriterMessageDataType")]
[ComVisible(true)]
public class DataSetWriterMessageDataTypeCollection : List<DataSetWriterMessageDataType>, ICloneable
{
	public DataSetWriterMessageDataTypeCollection()
	{
	}

	public DataSetWriterMessageDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public DataSetWriterMessageDataTypeCollection(IEnumerable<DataSetWriterMessageDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator DataSetWriterMessageDataTypeCollection(DataSetWriterMessageDataType[] values)
	{
		if (values != null)
		{
			return new DataSetWriterMessageDataTypeCollection(values);
		}
		return new DataSetWriterMessageDataTypeCollection();
	}

	public static explicit operator DataSetWriterMessageDataType[](DataSetWriterMessageDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataSetWriterMessageDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetWriterMessageDataTypeCollection dataSetWriterMessageDataTypeCollection = new DataSetWriterMessageDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataSetWriterMessageDataTypeCollection.Add((DataSetWriterMessageDataType)Utils.Clone(base[i]));
		}
		return dataSetWriterMessageDataTypeCollection;
	}
}
