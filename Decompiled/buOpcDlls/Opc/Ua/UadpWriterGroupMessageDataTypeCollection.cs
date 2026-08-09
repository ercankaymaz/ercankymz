using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfUadpWriterGroupMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UadpWriterGroupMessageDataType")]
[ComVisible(true)]
public class UadpWriterGroupMessageDataTypeCollection : List<UadpWriterGroupMessageDataType>, ICloneable
{
	public UadpWriterGroupMessageDataTypeCollection()
	{
	}

	public UadpWriterGroupMessageDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public UadpWriterGroupMessageDataTypeCollection(IEnumerable<UadpWriterGroupMessageDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator UadpWriterGroupMessageDataTypeCollection(UadpWriterGroupMessageDataType[] values)
	{
		if (values != null)
		{
			return new UadpWriterGroupMessageDataTypeCollection(values);
		}
		return new UadpWriterGroupMessageDataTypeCollection();
	}

	public static explicit operator UadpWriterGroupMessageDataType[](UadpWriterGroupMessageDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (UadpWriterGroupMessageDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UadpWriterGroupMessageDataTypeCollection uadpWriterGroupMessageDataTypeCollection = new UadpWriterGroupMessageDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			uadpWriterGroupMessageDataTypeCollection.Add((UadpWriterGroupMessageDataType)Utils.Clone(base[i]));
		}
		return uadpWriterGroupMessageDataTypeCollection;
	}
}
