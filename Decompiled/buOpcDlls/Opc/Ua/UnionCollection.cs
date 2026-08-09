using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfUnion", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Union")]
[ComVisible(true)]
public class UnionCollection : List<Union>, ICloneable
{
	public UnionCollection()
	{
	}

	public UnionCollection(int capacity)
		: base(capacity)
	{
	}

	public UnionCollection(IEnumerable<Union> collection)
		: base(collection)
	{
	}

	public static implicit operator UnionCollection(Union[] values)
	{
		if (values != null)
		{
			return new UnionCollection(values);
		}
		return new UnionCollection();
	}

	public static explicit operator Union[](UnionCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (UnionCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UnionCollection unionCollection = new UnionCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			unionCollection.Add((Union)Utils.Clone(base[i]));
		}
		return unionCollection;
	}
}
