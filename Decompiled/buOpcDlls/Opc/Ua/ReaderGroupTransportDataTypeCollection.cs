using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfReaderGroupTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ReaderGroupTransportDataType")]
[ComVisible(true)]
public class ReaderGroupTransportDataTypeCollection : List<ReaderGroupTransportDataType>, ICloneable
{
	public ReaderGroupTransportDataTypeCollection()
	{
	}

	public ReaderGroupTransportDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public ReaderGroupTransportDataTypeCollection(IEnumerable<ReaderGroupTransportDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator ReaderGroupTransportDataTypeCollection(ReaderGroupTransportDataType[] values)
	{
		if (values != null)
		{
			return new ReaderGroupTransportDataTypeCollection(values);
		}
		return new ReaderGroupTransportDataTypeCollection();
	}

	public static explicit operator ReaderGroupTransportDataType[](ReaderGroupTransportDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ReaderGroupTransportDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReaderGroupTransportDataTypeCollection readerGroupTransportDataTypeCollection = new ReaderGroupTransportDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			readerGroupTransportDataTypeCollection.Add((ReaderGroupTransportDataType)Utils.Clone(base[i]));
		}
		return readerGroupTransportDataTypeCollection;
	}
}
