using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[CollectionDataContract(Name = "ListOfBoolean", Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd", ItemName = "Boolean")]
[ComVisible(true)]
public class BooleanCollection : List<bool>, ICloneable
{
	public BooleanCollection()
	{
	}

	public BooleanCollection(IEnumerable<bool> collection)
		: base(collection)
	{
	}

	public BooleanCollection(int capacity)
		: base(capacity)
	{
	}

	public static BooleanCollection ToBooleanCollection(bool[] values)
	{
		if (values != null)
		{
			return new BooleanCollection(values);
		}
		return new BooleanCollection();
	}

	public static implicit operator BooleanCollection(bool[] values)
	{
		return ToBooleanCollection(values);
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new BooleanCollection(this);
	}
}
