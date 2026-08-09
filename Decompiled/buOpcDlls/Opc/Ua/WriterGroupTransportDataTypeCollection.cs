using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfWriterGroupTransportDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "WriterGroupTransportDataType")]
[ComVisible(true)]
public class WriterGroupTransportDataTypeCollection : List<WriterGroupTransportDataType>, ICloneable
{
	public WriterGroupTransportDataTypeCollection()
	{
	}

	public WriterGroupTransportDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public WriterGroupTransportDataTypeCollection(IEnumerable<WriterGroupTransportDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator WriterGroupTransportDataTypeCollection(WriterGroupTransportDataType[] values)
	{
		if (values != null)
		{
			return new WriterGroupTransportDataTypeCollection(values);
		}
		return new WriterGroupTransportDataTypeCollection();
	}

	public static explicit operator WriterGroupTransportDataType[](WriterGroupTransportDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (WriterGroupTransportDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		WriterGroupTransportDataTypeCollection writerGroupTransportDataTypeCollection = new WriterGroupTransportDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			writerGroupTransportDataTypeCollection.Add((WriterGroupTransportDataType)Utils.Clone(base[i]));
		}
		return writerGroupTransportDataTypeCollection;
	}
}
