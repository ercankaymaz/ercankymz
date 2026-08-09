using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataSetWriterDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetWriterDataType")]
[ComVisible(true)]
public class DataSetWriterDataTypeCollection : List<DataSetWriterDataType>, ICloneable
{
	public DataSetWriterDataTypeCollection()
	{
	}

	public DataSetWriterDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public DataSetWriterDataTypeCollection(IEnumerable<DataSetWriterDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator DataSetWriterDataTypeCollection(DataSetWriterDataType[] values)
	{
		if (values != null)
		{
			return new DataSetWriterDataTypeCollection(values);
		}
		return new DataSetWriterDataTypeCollection();
	}

	public static explicit operator DataSetWriterDataType[](DataSetWriterDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataSetWriterDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetWriterDataTypeCollection dataSetWriterDataTypeCollection = new DataSetWriterDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataSetWriterDataTypeCollection.Add((DataSetWriterDataType)Utils.Clone(base[i]));
		}
		return dataSetWriterDataTypeCollection;
	}
}
