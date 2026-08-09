using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfWriterGroupDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "WriterGroupDataType")]
[ComVisible(true)]
public class WriterGroupDataTypeCollection : List<WriterGroupDataType>, ICloneable
{
	public WriterGroupDataTypeCollection()
	{
	}

	public WriterGroupDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public WriterGroupDataTypeCollection(IEnumerable<WriterGroupDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator WriterGroupDataTypeCollection(WriterGroupDataType[] values)
	{
		if (values != null)
		{
			return new WriterGroupDataTypeCollection(values);
		}
		return new WriterGroupDataTypeCollection();
	}

	public static explicit operator WriterGroupDataType[](WriterGroupDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (WriterGroupDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		WriterGroupDataTypeCollection writerGroupDataTypeCollection = new WriterGroupDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			writerGroupDataTypeCollection.Add((WriterGroupDataType)Utils.Clone(base[i]));
		}
		return writerGroupDataTypeCollection;
	}
}
