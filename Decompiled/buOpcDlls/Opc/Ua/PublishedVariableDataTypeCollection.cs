using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfPublishedVariableDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PublishedVariableDataType")]
[ComVisible(true)]
public class PublishedVariableDataTypeCollection : List<PublishedVariableDataType>, ICloneable
{
	public PublishedVariableDataTypeCollection()
	{
	}

	public PublishedVariableDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public PublishedVariableDataTypeCollection(IEnumerable<PublishedVariableDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator PublishedVariableDataTypeCollection(PublishedVariableDataType[] values)
	{
		if (values != null)
		{
			return new PublishedVariableDataTypeCollection(values);
		}
		return new PublishedVariableDataTypeCollection();
	}

	public static explicit operator PublishedVariableDataType[](PublishedVariableDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (PublishedVariableDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PublishedVariableDataTypeCollection publishedVariableDataTypeCollection = new PublishedVariableDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			publishedVariableDataTypeCollection.Add((PublishedVariableDataType)Utils.Clone(base[i]));
		}
		return publishedVariableDataTypeCollection;
	}
}
