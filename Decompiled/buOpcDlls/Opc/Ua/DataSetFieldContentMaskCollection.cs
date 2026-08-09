using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDataSetFieldContentMask", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "DataSetFieldContentMask")]
[ComVisible(true)]
public class DataSetFieldContentMaskCollection : List<DataSetFieldContentMask>, ICloneable
{
	public DataSetFieldContentMaskCollection()
	{
	}

	public DataSetFieldContentMaskCollection(int capacity)
		: base(capacity)
	{
	}

	public DataSetFieldContentMaskCollection(IEnumerable<DataSetFieldContentMask> collection)
		: base(collection)
	{
	}

	public static implicit operator DataSetFieldContentMaskCollection(DataSetFieldContentMask[] values)
	{
		if (values != null)
		{
			return new DataSetFieldContentMaskCollection(values);
		}
		return new DataSetFieldContentMaskCollection();
	}

	public static explicit operator DataSetFieldContentMask[](DataSetFieldContentMaskCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DataSetFieldContentMaskCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetFieldContentMaskCollection dataSetFieldContentMaskCollection = new DataSetFieldContentMaskCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			dataSetFieldContentMaskCollection.Add((DataSetFieldContentMask)Utils.Clone(base[i]));
		}
		return dataSetFieldContentMaskCollection;
	}
}
