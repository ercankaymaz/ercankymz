using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfPubSubState", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "PubSubState")]
[ComVisible(true)]
public class PubSubStateCollection : List<PubSubState>, ICloneable
{
	public PubSubStateCollection()
	{
	}

	public PubSubStateCollection(int capacity)
		: base(capacity)
	{
	}

	public PubSubStateCollection(IEnumerable<PubSubState> collection)
		: base(collection)
	{
	}

	public static implicit operator PubSubStateCollection(PubSubState[] values)
	{
		if (values != null)
		{
			return new PubSubStateCollection(values);
		}
		return new PubSubStateCollection();
	}

	public static explicit operator PubSubState[](PubSubStateCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (PubSubStateCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PubSubStateCollection pubSubStateCollection = new PubSubStateCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			pubSubStateCollection.Add((PubSubState)Utils.Clone(base[i]));
		}
		return pubSubStateCollection;
	}
}
