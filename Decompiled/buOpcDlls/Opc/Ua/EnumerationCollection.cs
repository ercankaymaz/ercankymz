using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfEnumeration", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Enumeration")]
[ComVisible(true)]
public class EnumerationCollection : List<Enumeration>, ICloneable
{
	public EnumerationCollection()
	{
	}

	public EnumerationCollection(int capacity)
		: base(capacity)
	{
	}

	public EnumerationCollection(IEnumerable<Enumeration> collection)
		: base(collection)
	{
	}

	public static implicit operator EnumerationCollection(Enumeration[] values)
	{
		if (values != null)
		{
			return new EnumerationCollection(values);
		}
		return new EnumerationCollection();
	}

	public static explicit operator Enumeration[](EnumerationCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (EnumerationCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EnumerationCollection enumerationCollection = new EnumerationCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			enumerationCollection.Add((Enumeration)Utils.Clone(base[i]));
		}
		return enumerationCollection;
	}
}
