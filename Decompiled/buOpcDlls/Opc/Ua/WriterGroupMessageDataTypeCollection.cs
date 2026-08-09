using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfWriterGroupMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "WriterGroupMessageDataType")]
[ComVisible(true)]
public class WriterGroupMessageDataTypeCollection : List<WriterGroupMessageDataType>, ICloneable
{
	public WriterGroupMessageDataTypeCollection()
	{
	}

	public WriterGroupMessageDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public WriterGroupMessageDataTypeCollection(IEnumerable<WriterGroupMessageDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator WriterGroupMessageDataTypeCollection(WriterGroupMessageDataType[] values)
	{
		if (values != null)
		{
			return new WriterGroupMessageDataTypeCollection(values);
		}
		return new WriterGroupMessageDataTypeCollection();
	}

	public static explicit operator WriterGroupMessageDataType[](WriterGroupMessageDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (WriterGroupMessageDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		WriterGroupMessageDataTypeCollection writerGroupMessageDataTypeCollection = new WriterGroupMessageDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			writerGroupMessageDataTypeCollection.Add((WriterGroupMessageDataType)Utils.Clone(base[i]));
		}
		return writerGroupMessageDataTypeCollection;
	}
}
