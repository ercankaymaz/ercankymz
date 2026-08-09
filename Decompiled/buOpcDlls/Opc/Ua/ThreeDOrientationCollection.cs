using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfThreeDOrientation", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ThreeDOrientation")]
[ComVisible(true)]
public class ThreeDOrientationCollection : List<ThreeDOrientation>, ICloneable
{
	public ThreeDOrientationCollection()
	{
	}

	public ThreeDOrientationCollection(int capacity)
		: base(capacity)
	{
	}

	public ThreeDOrientationCollection(IEnumerable<ThreeDOrientation> collection)
		: base(collection)
	{
	}

	public static implicit operator ThreeDOrientationCollection(ThreeDOrientation[] values)
	{
		if (values != null)
		{
			return new ThreeDOrientationCollection(values);
		}
		return new ThreeDOrientationCollection();
	}

	public static explicit operator ThreeDOrientation[](ThreeDOrientationCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ThreeDOrientationCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ThreeDOrientationCollection threeDOrientationCollection = new ThreeDOrientationCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			threeDOrientationCollection.Add((ThreeDOrientation)Utils.Clone(base[i]));
		}
		return threeDOrientationCollection;
	}
}
