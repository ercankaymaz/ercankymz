using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfPublishedDataSetSourceDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PublishedDataSetSourceDataType")]
[ComVisible(true)]
public class PublishedDataSetSourceDataTypeCollection : List<PublishedDataSetSourceDataType>, ICloneable
{
	public PublishedDataSetSourceDataTypeCollection()
	{
	}

	public PublishedDataSetSourceDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public PublishedDataSetSourceDataTypeCollection(IEnumerable<PublishedDataSetSourceDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator PublishedDataSetSourceDataTypeCollection(PublishedDataSetSourceDataType[] values)
	{
		if (values != null)
		{
			return new PublishedDataSetSourceDataTypeCollection(values);
		}
		return new PublishedDataSetSourceDataTypeCollection();
	}

	public static explicit operator PublishedDataSetSourceDataType[](PublishedDataSetSourceDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (PublishedDataSetSourceDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PublishedDataSetSourceDataTypeCollection publishedDataSetSourceDataTypeCollection = new PublishedDataSetSourceDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			publishedDataSetSourceDataTypeCollection.Add((PublishedDataSetSourceDataType)Utils.Clone(base[i]));
		}
		return publishedDataSetSourceDataTypeCollection;
	}
}
