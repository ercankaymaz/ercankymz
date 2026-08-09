using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfVector", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Vector")]
[ComVisible(true)]
public class VectorCollection : List<Vector>, ICloneable
{
	public VectorCollection()
	{
	}

	public VectorCollection(int capacity)
		: base(capacity)
	{
	}

	public VectorCollection(IEnumerable<Vector> collection)
		: base(collection)
	{
	}

	public static implicit operator VectorCollection(Vector[] values)
	{
		if (values != null)
		{
			return new VectorCollection(values);
		}
		return new VectorCollection();
	}

	public static explicit operator Vector[](VectorCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (VectorCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		VectorCollection vectorCollection = new VectorCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			vectorCollection.Add((Vector)Utils.Clone(base[i]));
		}
		return vectorCollection;
	}
}
