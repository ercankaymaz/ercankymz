using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfGenericAttributeValue", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "GenericAttributeValue")]
[ComVisible(true)]
public class GenericAttributeValueCollection : List<GenericAttributeValue>, ICloneable
{
	public GenericAttributeValueCollection()
	{
	}

	public GenericAttributeValueCollection(int capacity)
		: base(capacity)
	{
	}

	public GenericAttributeValueCollection(IEnumerable<GenericAttributeValue> collection)
		: base(collection)
	{
	}

	public static implicit operator GenericAttributeValueCollection(GenericAttributeValue[] values)
	{
		if (values != null)
		{
			return new GenericAttributeValueCollection(values);
		}
		return new GenericAttributeValueCollection();
	}

	public static explicit operator GenericAttributeValue[](GenericAttributeValueCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (GenericAttributeValueCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		GenericAttributeValueCollection genericAttributeValueCollection = new GenericAttributeValueCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			genericAttributeValueCollection.Add((GenericAttributeValue)Utils.Clone(base[i]));
		}
		return genericAttributeValueCollection;
	}
}
