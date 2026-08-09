using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfPublishedDataSetDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PublishedDataSetDataType")]
[ComVisible(true)]
public class PublishedDataSetDataTypeCollection : List<PublishedDataSetDataType>, ICloneable
{
	public PublishedDataSetDataTypeCollection()
	{
	}

	public PublishedDataSetDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public PublishedDataSetDataTypeCollection(IEnumerable<PublishedDataSetDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator PublishedDataSetDataTypeCollection(PublishedDataSetDataType[] values)
	{
		if (values != null)
		{
			return new PublishedDataSetDataTypeCollection(values);
		}
		return new PublishedDataSetDataTypeCollection();
	}

	public static explicit operator PublishedDataSetDataType[](PublishedDataSetDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (PublishedDataSetDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PublishedDataSetDataTypeCollection publishedDataSetDataTypeCollection = new PublishedDataSetDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			publishedDataSetDataTypeCollection.Add((PublishedDataSetDataType)Utils.Clone(base[i]));
		}
		return publishedDataSetDataTypeCollection;
	}
}
