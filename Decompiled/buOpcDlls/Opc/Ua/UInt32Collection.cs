using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfUInt32", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "UInt32")]
[ComVisible(true)]
public class UInt32Collection : List<uint>, ICloneable
{
	public UInt32Collection()
	{
	}

	public UInt32Collection(int capacity)
		: base(capacity)
	{
	}

	public UInt32Collection(IEnumerable<uint> collection)
		: base(collection)
	{
	}

	public static UInt32Collection ToUInt32Collection(uint[] values)
	{
		if (values != null)
		{
			return new UInt32Collection(values);
		}
		return new UInt32Collection();
	}

	public static implicit operator UInt32Collection(uint[] values)
	{
		return ToUInt32Collection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new UInt32Collection(this);
	}
}
