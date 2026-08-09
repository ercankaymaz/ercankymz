using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfReaderGroupDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReaderGroupDataType")]
[ComVisible(true)]
public class ReaderGroupDataTypeCollection : List<ReaderGroupDataType>, ICloneable
{
	public ReaderGroupDataTypeCollection()
	{
	}

	public ReaderGroupDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public ReaderGroupDataTypeCollection(IEnumerable<ReaderGroupDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator ReaderGroupDataTypeCollection(ReaderGroupDataType[] values)
	{
		if (values != null)
		{
			return new ReaderGroupDataTypeCollection(values);
		}
		return new ReaderGroupDataTypeCollection();
	}

	public static explicit operator ReaderGroupDataType[](ReaderGroupDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ReaderGroupDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReaderGroupDataTypeCollection readerGroupDataTypeCollection = new ReaderGroupDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			readerGroupDataTypeCollection.Add((ReaderGroupDataType)Utils.Clone(base[i]));
		}
		return readerGroupDataTypeCollection;
	}
}
