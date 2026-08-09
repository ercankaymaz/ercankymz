using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfUadpDataSetReaderMessageDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UadpDataSetReaderMessageDataType")]
[ComVisible(true)]
public class UadpDataSetReaderMessageDataTypeCollection : List<UadpDataSetReaderMessageDataType>, ICloneable
{
	public UadpDataSetReaderMessageDataTypeCollection()
	{
	}

	public UadpDataSetReaderMessageDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public UadpDataSetReaderMessageDataTypeCollection(IEnumerable<UadpDataSetReaderMessageDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator UadpDataSetReaderMessageDataTypeCollection(UadpDataSetReaderMessageDataType[] values)
	{
		if (values != null)
		{
			return new UadpDataSetReaderMessageDataTypeCollection(values);
		}
		return new UadpDataSetReaderMessageDataTypeCollection();
	}

	public static explicit operator UadpDataSetReaderMessageDataType[](UadpDataSetReaderMessageDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (UadpDataSetReaderMessageDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UadpDataSetReaderMessageDataTypeCollection uadpDataSetReaderMessageDataTypeCollection = new UadpDataSetReaderMessageDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			uadpDataSetReaderMessageDataTypeCollection.Add((UadpDataSetReaderMessageDataType)Utils.Clone(base[i]));
		}
		return uadpDataSetReaderMessageDataTypeCollection;
	}
}
