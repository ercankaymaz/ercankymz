using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfCartesianCoordinates", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "CartesianCoordinates")]
[ComVisible(true)]
public class CartesianCoordinatesCollection : List<CartesianCoordinates>, ICloneable
{
	public CartesianCoordinatesCollection()
	{
	}

	public CartesianCoordinatesCollection(int capacity)
		: base(capacity)
	{
	}

	public CartesianCoordinatesCollection(IEnumerable<CartesianCoordinates> collection)
		: base(collection)
	{
	}

	public static implicit operator CartesianCoordinatesCollection(CartesianCoordinates[] values)
	{
		if (values != null)
		{
			return new CartesianCoordinatesCollection(values);
		}
		return new CartesianCoordinatesCollection();
	}

	public static explicit operator CartesianCoordinates[](CartesianCoordinatesCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (CartesianCoordinatesCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CartesianCoordinatesCollection cartesianCoordinatesCollection = new CartesianCoordinatesCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			cartesianCoordinatesCollection.Add((CartesianCoordinates)Utils.Clone(base[i]));
		}
		return cartesianCoordinatesCollection;
	}
}
