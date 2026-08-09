using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfRationalNumber", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "RationalNumber")]
[ComVisible(true)]
public class RationalNumberCollection : List<RationalNumber>, ICloneable
{
	public RationalNumberCollection()
	{
	}

	public RationalNumberCollection(int capacity)
		: base(capacity)
	{
	}

	public RationalNumberCollection(IEnumerable<RationalNumber> collection)
		: base(collection)
	{
	}

	public static implicit operator RationalNumberCollection(RationalNumber[] values)
	{
		if (values != null)
		{
			return new RationalNumberCollection(values);
		}
		return new RationalNumberCollection();
	}

	public static explicit operator RationalNumber[](RationalNumberCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (RationalNumberCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RationalNumberCollection rationalNumberCollection = new RationalNumberCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			rationalNumberCollection.Add((RationalNumber)Utils.Clone(base[i]));
		}
		return rationalNumberCollection;
	}
}
