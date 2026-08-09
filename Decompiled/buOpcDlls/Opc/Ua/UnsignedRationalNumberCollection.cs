using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[CollectionDataContract(Name = "ListOfUnsignedRationalNumber", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UnsignedRationalNumber")]
[ComVisible(true)]
public class UnsignedRationalNumberCollection : List<UnsignedRationalNumber>, ICloneable
{
	public UnsignedRationalNumberCollection()
	{
	}

	public UnsignedRationalNumberCollection(int capacity)
		: base(capacity)
	{
	}

	public UnsignedRationalNumberCollection(IEnumerable<UnsignedRationalNumber> collection)
		: base(collection)
	{
	}

	public static implicit operator UnsignedRationalNumberCollection(UnsignedRationalNumber[] values)
	{
		if (values != null)
		{
			return new UnsignedRationalNumberCollection(values);
		}
		return new UnsignedRationalNumberCollection();
	}

	public static explicit operator UnsignedRationalNumber[](UnsignedRationalNumberCollection values)
	{
		return values?.ToArray();
	}

	public object Clone()
	{
		return (UnsignedRationalNumberCollection)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UnsignedRationalNumberCollection unsignedRationalNumberCollection = new UnsignedRationalNumberCollection(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			unsignedRationalNumberCollection.Add((UnsignedRationalNumber)Utils.Clone(base[i]));
		}
		return unsignedRationalNumberCollection;
	}
}
