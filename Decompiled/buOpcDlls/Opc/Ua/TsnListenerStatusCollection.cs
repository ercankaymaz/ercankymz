using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfTsnListenerStatus", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TsnListenerStatus")]
[ComVisible(true)]
public class TsnListenerStatusCollection : List<TsnListenerStatus>, ICloneable
{
	public TsnListenerStatusCollection()
	{
	}

	public TsnListenerStatusCollection(int capacity)
		: base(capacity)
	{
	}

	public TsnListenerStatusCollection(IEnumerable<TsnListenerStatus> collection)
		: base(collection)
	{
	}

	public static implicit operator TsnListenerStatusCollection(TsnListenerStatus[] values)
	{
		if (values != null)
		{
			return new TsnListenerStatusCollection(values);
		}
		return new TsnListenerStatusCollection();
	}

	public static explicit operator TsnListenerStatus[](TsnListenerStatusCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (TsnListenerStatusCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TsnListenerStatusCollection tsnListenerStatusCollection = new TsnListenerStatusCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			tsnListenerStatusCollection.Add((TsnListenerStatus)Utils.Clone(base[i]));
		}
		return tsnListenerStatusCollection;
	}
}
