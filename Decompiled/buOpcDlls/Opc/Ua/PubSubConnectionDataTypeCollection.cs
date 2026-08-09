using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfPubSubConnectionDataType", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PubSubConnectionDataType")]
[ComVisible(true)]
public class PubSubConnectionDataTypeCollection : List<PubSubConnectionDataType>, ICloneable
{
	public PubSubConnectionDataTypeCollection()
	{
	}

	public PubSubConnectionDataTypeCollection(int capacity)
		: base(capacity)
	{
	}

	public PubSubConnectionDataTypeCollection(IEnumerable<PubSubConnectionDataType> collection)
		: base(collection)
	{
	}

	public static implicit operator PubSubConnectionDataTypeCollection(PubSubConnectionDataType[] values)
	{
		if (values != null)
		{
			return new PubSubConnectionDataTypeCollection(values);
		}
		return new PubSubConnectionDataTypeCollection();
	}

	public static explicit operator PubSubConnectionDataType[](PubSubConnectionDataTypeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (PubSubConnectionDataTypeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PubSubConnectionDataTypeCollection pubSubConnectionDataTypeCollection = new PubSubConnectionDataTypeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			pubSubConnectionDataTypeCollection.Add((PubSubConnectionDataType)Utils.Clone(base[i]));
		}
		return pubSubConnectionDataTypeCollection;
	}
}
