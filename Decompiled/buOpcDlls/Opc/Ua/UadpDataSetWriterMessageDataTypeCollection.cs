using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfUadpDataSetWriterMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UadpDataSetWriterMessageDataType")]
[ComVisible(true)]
public class UadpDataSetWriterMessageDataTypeCollection : List<UadpDataSetWriterMessageDataType>, ICloneable
{
	public UadpDataSetWriterMessageDataTypeCollection()
	{
	}

	public UadpDataSetWriterMessageDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public UadpDataSetWriterMessageDataTypeCollection(IEnumerable<UadpDataSetWriterMessageDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator UadpDataSetWriterMessageDataTypeCollection(UadpDataSetWriterMessageDataType[] values)
	{
		if (values != null)
		{
			return new UadpDataSetWriterMessageDataTypeCollection(values);
		}
		return new UadpDataSetWriterMessageDataTypeCollection();
	}

	public static explicit operator UadpDataSetWriterMessageDataType[](UadpDataSetWriterMessageDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (UadpDataSetWriterMessageDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UadpDataSetWriterMessageDataTypeCollection uadpDataSetWriterMessageDataTypeCollection = new UadpDataSetWriterMessageDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			uadpDataSetWriterMessageDataTypeCollection.Add((UadpDataSetWriterMessageDataType)Utils.Clone(base[i]));
		}
		return uadpDataSetWriterMessageDataTypeCollection;
	}
}
