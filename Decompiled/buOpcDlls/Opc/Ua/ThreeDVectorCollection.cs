using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfThreeDVector", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ThreeDVector")]
[ComVisible(true)]
public class ThreeDVectorCollection : List<ThreeDVector>, ICloneable
{
	public ThreeDVectorCollection()
	{
	}

	public ThreeDVectorCollection(int capacity)
		: base(capacity)
	{
	}

	public ThreeDVectorCollection(IEnumerable<ThreeDVector> collection)
		: base(collection)
	{
	}

	public static implicit operator ThreeDVectorCollection(ThreeDVector[] values)
	{
		if (values != null)
		{
			return new ThreeDVectorCollection(values);
		}
		return new ThreeDVectorCollection();
	}

	public static explicit operator ThreeDVector[](ThreeDVectorCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ThreeDVectorCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ThreeDVectorCollection threeDVectorCollection = new ThreeDVectorCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			threeDVectorCollection.Add((ThreeDVector)Utils.Clone(base[i]));
		}
		return threeDVectorCollection;
	}
}
