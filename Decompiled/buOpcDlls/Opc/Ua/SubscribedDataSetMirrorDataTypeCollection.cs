using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfSubscribedDataSetMirrorDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SubscribedDataSetMirrorDataType")]
[ComVisible(true)]
public class SubscribedDataSetMirrorDataTypeCollection : List<SubscribedDataSetMirrorDataType>, ICloneable
{
	public SubscribedDataSetMirrorDataTypeCollection()
	{
	}

	public SubscribedDataSetMirrorDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public SubscribedDataSetMirrorDataTypeCollection(IEnumerable<SubscribedDataSetMirrorDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator SubscribedDataSetMirrorDataTypeCollection(SubscribedDataSetMirrorDataType[] values)
	{
		if (values != null)
		{
			return new SubscribedDataSetMirrorDataTypeCollection(values);
		}
		return new SubscribedDataSetMirrorDataTypeCollection();
	}

	public static explicit operator SubscribedDataSetMirrorDataType[](SubscribedDataSetMirrorDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (SubscribedDataSetMirrorDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SubscribedDataSetMirrorDataTypeCollection subscribedDataSetMirrorDataTypeCollection = new SubscribedDataSetMirrorDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			subscribedDataSetMirrorDataTypeCollection.Add((SubscribedDataSetMirrorDataType)Utils.Clone(base[i]));
		}
		return subscribedDataSetMirrorDataTypeCollection;
	}
}
