using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfSByte", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "SByte")]
[ComVisible(true)]
public class SByteCollection : List<sbyte>, ICloneable
{
	public SByteCollection()
	{
	}

	public SByteCollection(int capacity)
		: base(capacity)
	{
	}

	public SByteCollection(IEnumerable<sbyte> collection)
		: base(collection)
	{
	}

	public static SByteCollection ToSByteCollection(sbyte[] values)
	{
		if (values != null)
		{
			return new SByteCollection(values);
		}
		return new SByteCollection();
	}

	public static implicit operator SByteCollection(sbyte[] values)
	{
		return ToSByteCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new SByteCollection(this);
	}
}
