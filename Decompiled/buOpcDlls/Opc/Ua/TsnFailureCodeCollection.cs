using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfTsnFailureCode", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "TsnFailureCode")]
[ComVisible(true)]
public class TsnFailureCodeCollection : List<TsnFailureCode>, ICloneable
{
	public TsnFailureCodeCollection()
	{
	}

	public TsnFailureCodeCollection(int capacity)
		: base(capacity)
	{
	}

	public TsnFailureCodeCollection(IEnumerable<TsnFailureCode> collection)
		: base(collection)
	{
	}

	public static implicit operator TsnFailureCodeCollection(TsnFailureCode[] values)
	{
		if (values != null)
		{
			return new TsnFailureCodeCollection(values);
		}
		return new TsnFailureCodeCollection();
	}

	public static explicit operator TsnFailureCode[](TsnFailureCodeCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (TsnFailureCodeCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		TsnFailureCodeCollection tsnFailureCodeCollection = new TsnFailureCodeCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			tsnFailureCodeCollection.Add((TsnFailureCode)Utils.Clone(base[i]));
		}
		return tsnFailureCodeCollection;
	}
}
