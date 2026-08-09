using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfNegotiationStatus", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "NegotiationStatus")]
[ComVisible(true)]
public class NegotiationStatusCollection : List<NegotiationStatus>, ICloneable
{
	public NegotiationStatusCollection()
	{
	}

	public NegotiationStatusCollection(int capacity)
		: base(capacity)
	{
	}

	public NegotiationStatusCollection(IEnumerable<NegotiationStatus> collection)
		: base(collection)
	{
	}

	public static implicit operator NegotiationStatusCollection(NegotiationStatus[] values)
	{
		if (values != null)
		{
			return new NegotiationStatusCollection(values);
		}
		return new NegotiationStatusCollection();
	}

	public static explicit operator NegotiationStatus[](NegotiationStatusCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (NegotiationStatusCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NegotiationStatusCollection negotiationStatusCollection = new NegotiationStatusCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			negotiationStatusCollection.Add((NegotiationStatus)Utils.Clone(base[i]));
		}
		return negotiationStatusCollection;
	}
}
