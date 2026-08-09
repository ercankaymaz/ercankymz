using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfTsnTalkerStatus", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TsnTalkerStatus")]
[ComVisible(true)]
public class TsnTalkerStatusCollection : List<TsnTalkerStatus>, ICloneable
{
	public TsnTalkerStatusCollection()
	{
	}

	public TsnTalkerStatusCollection(int capacity)
		: base(capacity)
	{
	}

	public TsnTalkerStatusCollection(IEnumerable<TsnTalkerStatus> collection)
		: base(collection)
	{
	}

	public static implicit operator TsnTalkerStatusCollection(TsnTalkerStatus[] values)
	{
		if (values != null)
		{
			return new TsnTalkerStatusCollection(values);
		}
		return new TsnTalkerStatusCollection();
	}

	public static explicit operator TsnTalkerStatus[](TsnTalkerStatusCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (TsnTalkerStatusCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TsnTalkerStatusCollection tsnTalkerStatusCollection = new TsnTalkerStatusCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			tsnTalkerStatusCollection.Add((TsnTalkerStatus)Utils.Clone(base[i]));
		}
		return tsnTalkerStatusCollection;
	}
}
