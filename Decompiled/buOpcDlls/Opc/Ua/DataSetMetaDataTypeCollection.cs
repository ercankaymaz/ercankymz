using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataSetMetaDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetMetaDataType")]
[ComVisible(true)]
public class DataSetMetaDataTypeCollection : List<DataSetMetaDataType>, ICloneable
{
	public DataSetMetaDataTypeCollection()
	{
	}

	public DataSetMetaDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public DataSetMetaDataTypeCollection(IEnumerable<DataSetMetaDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator DataSetMetaDataTypeCollection(DataSetMetaDataType[] values)
	{
		if (values != null)
		{
			return new DataSetMetaDataTypeCollection(values);
		}
		return new DataSetMetaDataTypeCollection();
	}

	public static explicit operator DataSetMetaDataType[](DataSetMetaDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataSetMetaDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetMetaDataTypeCollection dataSetMetaDataTypeCollection = new DataSetMetaDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataSetMetaDataTypeCollection.Add((DataSetMetaDataType)Utils.Clone(base[i]));
		}
		return dataSetMetaDataTypeCollection;
	}
}
