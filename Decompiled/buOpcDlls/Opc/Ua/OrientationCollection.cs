using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfOrientation", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Orientation")]
[ComVisible(true)]
public class OrientationCollection : List<Orientation>, ICloneable
{
	public OrientationCollection()
	{
	}

	public OrientationCollection(int capacity)
		: base(capacity)
	{
	}

	public OrientationCollection(IEnumerable<Orientation> collection)
		: base(collection)
	{
	}

	public static implicit operator OrientationCollection(Orientation[] values)
	{
		if (values != null)
		{
			return new OrientationCollection(values);
		}
		return new OrientationCollection();
	}

	public static explicit operator Orientation[](OrientationCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (OrientationCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		OrientationCollection orientationCollection = new OrientationCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			orientationCollection.Add((Orientation)Utils.Clone(base[i]));
		}
		return orientationCollection;
	}
}
