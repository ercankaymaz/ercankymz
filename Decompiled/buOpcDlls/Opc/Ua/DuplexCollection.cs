using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfDuplex", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Duplex")]
[ComVisible(true)]
public class DuplexCollection : List<Duplex>, ICloneable
{
	public DuplexCollection()
	{
	}

	public DuplexCollection(int capacity)
		: base(capacity)
	{
	}

	public DuplexCollection(IEnumerable<Duplex> collection)
		: base(collection)
	{
	}

	public static implicit operator DuplexCollection(Duplex[] values)
	{
		if (values != null)
		{
			return new DuplexCollection(values);
		}
		return new DuplexCollection();
	}

	public static explicit operator Duplex[](DuplexCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (DuplexCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DuplexCollection duplexCollection = new DuplexCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			duplexCollection.Add((Duplex)Utils.Clone(base[i]));
		}
		return duplexCollection;
	}
}
