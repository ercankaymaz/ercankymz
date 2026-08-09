using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataSetReaderMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetReaderMessageDataType")]
[ComVisible(true)]
public class DataSetReaderMessageDataTypeCollection : List<DataSetReaderMessageDataType>, ICloneable
{
	public DataSetReaderMessageDataTypeCollection()
	{
	}

	public DataSetReaderMessageDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public DataSetReaderMessageDataTypeCollection(IEnumerable<DataSetReaderMessageDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator DataSetReaderMessageDataTypeCollection(DataSetReaderMessageDataType[] values)
	{
		if (values != null)
		{
			return new DataSetReaderMessageDataTypeCollection(values);
		}
		return new DataSetReaderMessageDataTypeCollection();
	}

	public static explicit operator DataSetReaderMessageDataType[](DataSetReaderMessageDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataSetReaderMessageDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetReaderMessageDataTypeCollection dataSetReaderMessageDataTypeCollection = new DataSetReaderMessageDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataSetReaderMessageDataTypeCollection.Add((DataSetReaderMessageDataType)Utils.Clone(base[i]));
		}
		return dataSetReaderMessageDataTypeCollection;
	}
}
