using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfInt64", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Int64")]
[ComVisible(true)]
public class Int64Collection : List<long>, ICloneable
{
	public Int64Collection()
	{
	}

	public Int64Collection(int capacity)
		: base(capacity)
	{
	}

	public Int64Collection(IEnumerable<long> collection)
		: base(collection)
	{
	}

	public static Int64Collection ToInt64Collection(long[] values)
	{
		if (values != null)
		{
			return new Int64Collection(values);
		}
		return new Int64Collection();
	}

	public static implicit operator Int64Collection(long[] values)
	{
		return ToInt64Collection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new Int64Collection(this);
	}
}
