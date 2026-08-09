using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfPubSubGroupDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PubSubGroupDataType")]
[ComVisible(true)]
public class PubSubGroupDataTypeCollection : List<PubSubGroupDataType>, ICloneable
{
	public PubSubGroupDataTypeCollection()
	{
	}

	public PubSubGroupDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public PubSubGroupDataTypeCollection(IEnumerable<PubSubGroupDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator PubSubGroupDataTypeCollection(PubSubGroupDataType[] values)
	{
		if (values != null)
		{
			return new PubSubGroupDataTypeCollection(values);
		}
		return new PubSubGroupDataTypeCollection();
	}

	public static explicit operator PubSubGroupDataType[](PubSubGroupDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (PubSubGroupDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PubSubGroupDataTypeCollection pubSubGroupDataTypeCollection = new PubSubGroupDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			pubSubGroupDataTypeCollection.Add((PubSubGroupDataType)Utils.Clone(base[i]));
		}
		return pubSubGroupDataTypeCollection;
	}
}
