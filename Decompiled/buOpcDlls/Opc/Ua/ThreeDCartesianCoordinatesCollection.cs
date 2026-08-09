using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfThreeDCartesianCoordinates", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "ThreeDCartesianCoordinates")]
[ComVisible(true)]
public class ThreeDCartesianCoordinatesCollection : List<ThreeDCartesianCoordinates>, ICloneable
{
	public ThreeDCartesianCoordinatesCollection()
	{
	}

	public ThreeDCartesianCoordinatesCollection(int capacity)
		: base(capacity)
	{
	}

	public ThreeDCartesianCoordinatesCollection(IEnumerable<ThreeDCartesianCoordinates> collection)
		: base(collection)
	{
	}

	public static implicit operator ThreeDCartesianCoordinatesCollection(ThreeDCartesianCoordinates[] values)
	{
		if (values != null)
		{
			return new ThreeDCartesianCoordinatesCollection(values);
		}
		return new ThreeDCartesianCoordinatesCollection();
	}

	public static explicit operator ThreeDCartesianCoordinates[](ThreeDCartesianCoordinatesCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (ThreeDCartesianCoordinatesCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ThreeDCartesianCoordinatesCollection threeDCartesianCoordinatesCollection = new ThreeDCartesianCoordinatesCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			threeDCartesianCoordinatesCollection.Add((ThreeDCartesianCoordinates)Utils.Clone(base[i]));
		}
		return threeDCartesianCoordinatesCollection;
	}
}
