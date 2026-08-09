using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataSetOrderingType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetOrderingType")]
[ComVisible(true)]
public class DataSetOrderingTypeCollection : List<DataSetOrderingType>, ICloneable
{
	public DataSetOrderingTypeCollection()
	{
	}

	public DataSetOrderingTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public DataSetOrderingTypeCollection(IEnumerable<DataSetOrderingType> collection)
		: base(collection)
	{
	}

	public static implicit operator DataSetOrderingTypeCollection(DataSetOrderingType[] values)
	{
		if (values != null)
		{
			return new DataSetOrderingTypeCollection(values);
		}
		return new DataSetOrderingTypeCollection();
	}

	public static explicit operator DataSetOrderingType[](DataSetOrderingTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataSetOrderingTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetOrderingTypeCollection dataSetOrderingTypeCollection = new DataSetOrderingTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataSetOrderingTypeCollection.Add((DataSetOrderingType)Utils.Clone(base[i]));
		}
		return dataSetOrderingTypeCollection;
	}
}
