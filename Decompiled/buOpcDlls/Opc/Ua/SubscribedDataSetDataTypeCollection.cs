using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfSubscribedDataSetDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SubscribedDataSetDataType")]
[ComVisible(true)]
public class SubscribedDataSetDataTypeCollection : List<SubscribedDataSetDataType>, ICloneable
{
	public SubscribedDataSetDataTypeCollection()
	{
	}

	public SubscribedDataSetDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public SubscribedDataSetDataTypeCollection(IEnumerable<SubscribedDataSetDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator SubscribedDataSetDataTypeCollection(SubscribedDataSetDataType[] values)
	{
		if (values != null)
		{
			return new SubscribedDataSetDataTypeCollection(values);
		}
		return new SubscribedDataSetDataTypeCollection();
	}

	public static explicit operator SubscribedDataSetDataType[](SubscribedDataSetDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (SubscribedDataSetDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SubscribedDataSetDataTypeCollection subscribedDataSetDataTypeCollection = new SubscribedDataSetDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			subscribedDataSetDataTypeCollection.Add((SubscribedDataSetDataType)Utils.Clone(base[i]));
		}
		return subscribedDataSetDataTypeCollection;
	}
}
