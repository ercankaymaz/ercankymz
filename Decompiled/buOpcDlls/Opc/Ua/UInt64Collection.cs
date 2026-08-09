using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfUInt64", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UInt64")]
[ComVisible(true)]
public class UInt64Collection : List<ulong>, ICloneable
{
	public UInt64Collection()
	{
	}

	public UInt64Collection(int capacity)
		: base(capacity)
	{
	}

	public UInt64Collection(IEnumerable<ulong> collection)
		: base(collection)
	{
	}

	public static UInt64Collection ToUInt64Collection(ulong[] values)
	{
		if (values != null)
		{
			return new UInt64Collection(values);
		}
		return new UInt64Collection();
	}

	public static implicit operator UInt64Collection(ulong[] values)
	{
		return ToUInt64Collection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new UInt64Collection(this);
	}
}
