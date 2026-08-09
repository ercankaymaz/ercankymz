using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfUInt16", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UInt16")]
[ComVisible(true)]
public class UInt16Collection : List<ushort>, ICloneable
{
	public UInt16Collection()
	{
	}

	public UInt16Collection(int capacity)
		: base(capacity)
	{
	}

	public UInt16Collection(IEnumerable<ushort> collection)
		: base(collection)
	{
	}

	public static UInt16Collection ToUInt16Collection(ushort[] values)
	{
		if (values != null)
		{
			return new UInt16Collection(values);
		}
		return new UInt16Collection();
	}

	public static implicit operator UInt16Collection(ushort[] values)
	{
		return ToUInt16Collection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new UInt16Collection(this);
	}
}
