using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfPublishedDataItemsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PublishedDataItemsDataType")]
[ComVisible(true)]
public class PublishedDataItemsDataTypeCollection : List<PublishedDataItemsDataType>, ICloneable
{
	public PublishedDataItemsDataTypeCollection()
	{
	}

	public PublishedDataItemsDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public PublishedDataItemsDataTypeCollection(IEnumerable<PublishedDataItemsDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator PublishedDataItemsDataTypeCollection(PublishedDataItemsDataType[] values)
	{
		if (values != null)
		{
			return new PublishedDataItemsDataTypeCollection(values);
		}
		return new PublishedDataItemsDataTypeCollection();
	}

	public static explicit operator PublishedDataItemsDataType[](PublishedDataItemsDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (PublishedDataItemsDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PublishedDataItemsDataTypeCollection publishedDataItemsDataTypeCollection = new PublishedDataItemsDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			publishedDataItemsDataTypeCollection.Add((PublishedDataItemsDataType)Utils.Clone(base[i]));
		}
		return publishedDataItemsDataTypeCollection;
	}
}
