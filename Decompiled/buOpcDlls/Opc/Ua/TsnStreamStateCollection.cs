using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfTsnStreamState", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TsnStreamState")]
[ComVisible(true)]
public class TsnStreamStateCollection : List<TsnStreamState>, ICloneable
{
	public TsnStreamStateCollection()
	{
	}

	public TsnStreamStateCollection(int capacity)
		: base(capacity)
	{
	}

	public TsnStreamStateCollection(IEnumerable<TsnStreamState> collection)
		: base(collection)
	{
	}

	public static implicit operator TsnStreamStateCollection(TsnStreamState[] values)
	{
		if (values != null)
		{
			return new TsnStreamStateCollection(values);
		}
		return new TsnStreamStateCollection();
	}

	public static explicit operator TsnStreamState[](TsnStreamStateCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (TsnStreamStateCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TsnStreamStateCollection tsnStreamStateCollection = new TsnStreamStateCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			tsnStreamStateCollection.Add((TsnStreamState)Utils.Clone(base[i]));
		}
		return tsnStreamStateCollection;
	}
}
