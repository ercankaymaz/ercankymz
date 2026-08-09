using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataSetReaderDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetReaderDataType")]
[ComVisible(true)]
public class DataSetReaderDataTypeCollection : List<DataSetReaderDataType>, ICloneable
{
	public DataSetReaderDataTypeCollection()
	{
	}

	public DataSetReaderDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public DataSetReaderDataTypeCollection(IEnumerable<DataSetReaderDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator DataSetReaderDataTypeCollection(DataSetReaderDataType[] values)
	{
		if (values != null)
		{
			return new DataSetReaderDataTypeCollection(values);
		}
		return new DataSetReaderDataTypeCollection();
	}

	public static explicit operator DataSetReaderDataType[](DataSetReaderDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataSetReaderDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetReaderDataTypeCollection dataSetReaderDataTypeCollection = new DataSetReaderDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataSetReaderDataTypeCollection.Add((DataSetReaderDataType)Utils.Clone(base[i]));
		}
		return dataSetReaderDataTypeCollection;
	}
}
