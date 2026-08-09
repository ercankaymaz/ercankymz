using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfPublishedEventsDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PublishedEventsDataType")]
[ComVisible(true)]
public class PublishedEventsDataTypeCollection : List<PublishedEventsDataType>, ICloneable
{
	public PublishedEventsDataTypeCollection()
	{
	}

	public PublishedEventsDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public PublishedEventsDataTypeCollection(IEnumerable<PublishedEventsDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator PublishedEventsDataTypeCollection(PublishedEventsDataType[] values)
	{
		if (values != null)
		{
			return new PublishedEventsDataTypeCollection(values);
		}
		return new PublishedEventsDataTypeCollection();
	}

	public static explicit operator PublishedEventsDataType[](PublishedEventsDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (PublishedEventsDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PublishedEventsDataTypeCollection publishedEventsDataTypeCollection = new PublishedEventsDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			publishedEventsDataTypeCollection.Add((PublishedEventsDataType)Utils.Clone(base[i]));
		}
		return publishedEventsDataTypeCollection;
	}
}
