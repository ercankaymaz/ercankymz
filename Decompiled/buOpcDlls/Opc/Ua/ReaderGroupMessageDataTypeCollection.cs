using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfReaderGroupMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReaderGroupMessageDataType")]
[ComVisible(true)]
public class ReaderGroupMessageDataTypeCollection : List<ReaderGroupMessageDataType>, ICloneable
{
	public ReaderGroupMessageDataTypeCollection()
	{
	}

	public ReaderGroupMessageDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public ReaderGroupMessageDataTypeCollection(IEnumerable<ReaderGroupMessageDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator ReaderGroupMessageDataTypeCollection(ReaderGroupMessageDataType[] values)
	{
		if (values != null)
		{
			return new ReaderGroupMessageDataTypeCollection(values);
		}
		return new ReaderGroupMessageDataTypeCollection();
	}

	public static explicit operator ReaderGroupMessageDataType[](ReaderGroupMessageDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ReaderGroupMessageDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReaderGroupMessageDataTypeCollection readerGroupMessageDataTypeCollection = new ReaderGroupMessageDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			readerGroupMessageDataTypeCollection.Add((ReaderGroupMessageDataType)Utils.Clone(base[i]));
		}
		return readerGroupMessageDataTypeCollection;
	}
}
